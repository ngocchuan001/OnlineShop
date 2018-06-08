using AutoMapper;
using OnlineShop.Application.ViewModels.Blog;
using OnlineShop.Application.ViewModels.Common;
using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Application.ViewModels.System;
using OnlineShop.Data.Entities;
using System;

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

            CreateMap<AppUserViewModel, AppUser>()
            .ConstructUsing(c => new AppUser(c.Id.GetValueOrDefault(Guid.Empty), c.FullName, c.UserName,
            c.Email, c.PhoneNumber, c.Avatar, c.Status));

            CreateMap<PermissionViewModel, Permission>()
            .ConstructUsing(c => new Permission(c.RoleId, c.FunctionId, c.CanCreate, c.CanRead, c.CanUpdate, c.CanDelete));



            CreateMap<BillViewModel, Bill>()
              .ConstructUsing(c => new Bill(c.Id, c.CustomerName, c.CustomerAddress,
              c.CustomerMobile, c.CustomerMessage, c.BillStatus,
              c.PaymentMethod, c.Status, c.CustomerId));

            CreateMap<BillDetailViewModel, BillDetail>()
              .ConstructUsing(c => new BillDetail(c.Id, c.BillId, c.ProductId,
              c.Quantity, c.Price, c.ColorId, c.SizeId));


            CreateMap<ContactViewModel, Contact>()
                .ConstructUsing(c => new Contact(c.Id, c.Name, c.Phone, c.Email, c.Website, c.Address, c.Other, c.Lng, c.Lat, c.Status));

            CreateMap<FeedbackViewModel, Feedback>()
                .ConstructUsing(c => new Feedback(c.Id, c.Name, c.Email, c.Message, c.Status));

            CreateMap<PageViewModel, Page>()
             .ConstructUsing(c => new Page(c.Id, c.Name, c.Alias, c.Content, c.Status));
        }
    }
}