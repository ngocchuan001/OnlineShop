using AutoMapper;
using OnlineShop.Application.ViewModels.Product;
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
            CreateMap<ProductViewModel, Product>().ConstructUsing(n => new Product(
                n.Name, n.CategoryId,n.Image, n.Price, n.PromotionPrice, n.OriginalPrice, 
                n.Description,n.Content, n.HomeFlag, n.HotFlag, n.ViewCount, n.Tags, 
                n.Unit, n.Status, n.SeoPageTitle, n.SeoKeywords, n.SeoAlias, n.SeoDescription));
        }
    }
}