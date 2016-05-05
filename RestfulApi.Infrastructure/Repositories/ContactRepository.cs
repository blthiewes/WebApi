using System;
using System.Linq;
using System.Net;
using AutoMapper;
using PartyV5.ServiceModel.Enumerations;
using PartyV5.ServiceModel.Messages;
using RestfulApi.Domain;
using RestfulApi.Domain.Repositories;
using ServiceStack;

namespace RestfulApi.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private Func<IServiceClient> _mdmPartyServiceFactory;

        public ContactRepository(string mdmPartyServiceEndpointUrl)
        {
            _mdmPartyServiceFactory = () => new JsonServiceClient(mdmPartyServiceEndpointUrl);
        }

        public void SetMdmPartyServiceFactory(Func<IServiceClient> factory)
        {
            _mdmPartyServiceFactory = factory;
        }

        public Contact GetOnlineContact(string partyCode)
        {

            using (var mdmPartyService = _mdmPartyServiceFactory())
            {
                var request = new ReadContacts
                {
                    PartyCode = partyCode.Trim(),
                    DepartmentType = DepartmentType.ONLINE.ToString()
                };
                try
                {

                    ReadContactsResponse response = mdmPartyService.Get(request);

                    if (response.ContactInfo == null || !response.ContactInfo.Any())
                        return null;

                    return
                        Mapper.Map<PartyV5.ServiceModel.Dtos.Contact, Contact>(response.ContactInfo.First());
                }
                catch (WebException exception)
                {
                    if (((HttpWebResponse)exception.Response).StatusCode == HttpStatusCode.NotFound)
                        return null;
                    throw;
                }
                catch (WebServiceException exception)
                {
                    if (exception.StatusCode == (int)HttpStatusCode.NotFound)
                        return null;
                    throw;
                }
            }
        }
    }
}
