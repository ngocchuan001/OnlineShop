using AutoMapper;

namespace OnlineShop.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configuration()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new DomainToViewModelMappingProfile());
                config.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}