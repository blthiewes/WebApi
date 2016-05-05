using System;
using System.Collections.Generic;
using AutoMapper;
using RestfulApi.Application.Interfaces;
using RestfulApi.Domain.Repositories;
using RestfulApi.Infrastructure.Services.Interfaces;
using RestfulApi.ServiceModel;
using RestfulApi.ServiceModel.RequestMessages;

namespace RestfulApi.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IErrorLogService _errorLogService;
        public CustomerService(ICustomerRepository customerRepository, IContactRepository contactRepository, IErrorLogService errorLogService)
        {
            _customerRepository = customerRepository;
            _contactRepository = contactRepository;
            _errorLogService = errorLogService;
        }

        public Customer GetByPartyNumber(int partyNumber)
        {
            try
            {
                var customer = _customerRepository.GetByPartyNumber(partyNumber);
                return Mapper.Map<Domain.Customer, Customer>(customer);
            }
            catch (Exception ex)
            {
                _errorLogService.LogServerError(ex, string.Empty, string.Empty);
                throw;
            }

        }

        public Customer GetByCustomerCode(string customerCode)
        {
            try
            {
                var customer = _customerRepository.GetByCustomerCode(customerCode);
                return Mapper.Map<Domain.Customer, Customer>(customer);
            }
            catch (Exception ex)
            {
                _errorLogService.LogServerError(ex, string.Empty, string.Empty);
                throw;
            }

        }

        public PagedCollection<Customer> SearchCustomers(string term, int offset, int limit)
        {
            var pagedCustomers = new PagedCollection<Customer>();
            try
            {
                int total;
                var customers = _customerRepository.SearchCustomers(term, offset, limit, out total);
                pagedCustomers.Items = Mapper.Map<List<Domain.Customer>, List<Customer>>(customers);
                pagedCustomers.Total = total;
                pagedCustomers.Limit = limit;
                pagedCustomers.Offset = offset;
                return pagedCustomers;
            }
            catch (Exception ex)
            {
                _errorLogService.LogServerError(ex, string.Empty, string.Empty);
                throw;
            }
        }

        public string GetBOLComment(string partyLocationOrCode)
        {
            try
            {
                return _customerRepository.GetBOLComment(partyLocationOrCode);
            }
            catch (Exception ex)
            {
                _errorLogService.LogServerError(ex, string.Empty, string.Empty);
                throw;
            }
        }

        public Contact GetOnlineContact(GetOnlineContactRequest request)
        {
            try
            {
                return Mapper.Map<Domain.Contact, Contact>(_contactRepository.GetOnlineContact(request.PartyCode));
            }
            catch (Exception ex)
            {
                _errorLogService.LogServerError(ex, request.UserName, string.Empty);
            }
            return null;
        }
    }
}
