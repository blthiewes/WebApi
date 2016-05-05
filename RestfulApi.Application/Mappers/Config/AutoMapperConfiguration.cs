using AutoMapper;

namespace RestfulApi.Application.Mappers.Config
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.AddProfile(new CustomerMapper());
            Mapper.AddProfile(new ContactMapper());
        }
    }
}
