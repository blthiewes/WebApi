using System.Linq;
using AutoMapper;
using PartyV5.ServiceModel.Dtos;

namespace RestfulApi.Infrastructure.Mappers
{
    public class ContactAutoMapper : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Contact, Domain.Contact>()
                .ForMember(dest => dest.EmailAddress, opts => opts.MapFrom(src => src.EmailAddress.FirstOrDefault().Detail))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber.FirstOrDefault().Detail));
        }
    }
}
