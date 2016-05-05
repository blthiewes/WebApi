using AutoMapper;

namespace RestfulApi.Infrastructure.Mappers.Config
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.AddProfile(new CustomerAutoMapper());
            Mapper.AddProfile(new ContactAutoMapper());
        }
    }
}
