using AutoMapper;
using RestfulApi.Domain;

namespace RestfulApi.Application.Mappers
{
    public class CustomerMapper : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Customer, ServiceModel.Customer>();
            Mapper.CreateMap<ServiceModel.Customer, Customer>();
        }
    }
}
