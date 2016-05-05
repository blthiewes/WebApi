using AutoMapper;
using PartyV5.ServiceModel.Dtos;

namespace RestfulApi.Infrastructure.Mappers
{
    public class CustomerAutoMapper : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Customer, Domain.Customer>()
                .ForMember(dest => dest.OwningBranch, opts => opts.MapFrom(src => src.Branch))
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.PhysicalAddress))
                .ForMember(dest => dest.SalesRep, opts => opts.MapFrom(src => src.SalesPerson))
                .ForMember(dest => dest.SecondSalesRep, opts => opts.MapFrom(src => src.SecondSalesPerson));

            Mapper.CreateMap<CustomerDetails, Domain.Customer>()
                .ForMember(dest => dest.OwningBranch, opts => opts.MapFrom(src => src.Branch))
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.PhysicalAddress))
                .ForMember(dest => dest.SalesRep, opts => opts.MapFrom(src => src.SalesPerson))
                .ForMember(dest => dest.SecondSalesRep, opts => opts.MapFrom(src => src.SecondSalesPerson))
                .ForMember(dest => dest.PrimaryCustomerReferenceNumTypeRDN, opts => opts.MapFrom(src => src.PrimaryCustomerReferenceNumTypeRDN))
                .ForMember(dest => dest.PrimaryBillToReferenceNumTypeRDN, opts => opts.MapFrom(src => src.PrimaryBillToReferenceNumTypeRDN));
        }
    }
}
