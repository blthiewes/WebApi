using AutoMapper;
using RestfulApi.Domain;

namespace RestfulApi.Application.Mappers
{
    public class ContactMapper : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Contact, ServiceModel.Contact>();
            Mapper.CreateMap<ServiceModel.Contact, Contact>();
        }
    }
}
