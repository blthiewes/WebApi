using System;
using System.Collections.Generic;
using System.Linq;
using PartyV5.ServiceModel.Messages;
using RestfulApi.Domain;
using RestfulApi.Domain.Repositories;
using RestfulApi.Infrastructure.Constants;
using ServiceStack;

namespace RestfulApi.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private Func<IServiceClient> _customerClientFactory;

        public void SetCustomerClientFactory(Func<IServiceClient> customerClientFactory)
        {
            _customerClientFactory = customerClientFactory;
        }
        public CustomerRepository(string mdmPartyServiceEndpointUrl)
        {

            _customerClientFactory = () => new JsonServiceClient(mdmPartyServiceEndpointUrl);
        }

        public Customer GetByPartyNumber(int partyNumber)
        {
            using (var mdmPartyService = _customerClientFactory())
            {
                var request = new ReadCustomerDetails { PartyNumberOrCode = partyNumber.ToString("D") };
                var customerDetailsResponse = mdmPartyService.Get(request);
                return AutoMapper.Mapper.Map<PartyV5.ServiceModel.Dtos.CustomerDetails, Customer>(customerDetailsResponse.Customer);
            }
        }

        public Customer GetByCustomerCode(string code)
        {
            using (var mdmPartyService = _customerClientFactory())
            {
                var request = new ReadCustomerDetails { PartyNumberOrCode = code };
                var customerResponse = mdmPartyService.Get(request);
                return AutoMapper.Mapper.Map<PartyV5.ServiceModel.Dtos.CustomerDetails, Customer>(customerResponse.Customer);
            }
        }

        public List<Customer> SearchCustomers(string term, int offset, int limit, out int total)
        {
            using (var mdmPartyService = _customerClientFactory())
            {
                var request = new SearchCustomers
                {
                    SourceSystem = Common.SOURCE_SYSTEM,
                    Skip = offset,
                    Take = limit,
                    SearchText = term
                };
                var response = mdmPartyService.Get(request);
                total = (int)response.TotalRecords;
                return response.Customers.Select(c => new Customer
                {
                    Name = c.Name,
                    PartyCode = c.PartyCode,
                    PartyNumber = c.PartyNumber,
                    OwningBranch = new Branch
                    {
                        PartyCode = c.Branch,
                        PartyNumber = c.BranchNumber.GetValueOrDefault()
                    }
                }).ToList();
            }
        }

        public string GetBOLComment(string partyNumberOrCode)
        {
            using (var mdmPartyService = _customerClientFactory())
            {
                var request = new ReadCustomerDetails { PartyNumberOrCode = partyNumberOrCode };
                var customerResponse = mdmPartyService.Get(request);
                return customerResponse.Customer.BOLComment;
            }
        }
    }
}
