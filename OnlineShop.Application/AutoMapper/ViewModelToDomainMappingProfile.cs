using AutoMapper;
using OnlineShop.Application.ViewModels;
using OnlineShop.Data.Entities;

namespace OnlineShop.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>().ConstructUsing(n=> new ProductCategory(
                n.Name, n.Description, n.ParentId, n.HomeOrder, n.Image, n.HomeFlag, 
                n.SeoPageTitle, n.SeoAlias, n.SeoKeywords, n.SeoDescription, n.Status, n.SortOrder));
        }
    }
}