using AutoMapper;
using OnlineShop.Application.ViewModels;
using OnlineShop.Data.Entities;

namespace OnlineShop.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}