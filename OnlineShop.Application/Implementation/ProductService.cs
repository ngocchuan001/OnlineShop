using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Common;
using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Data.Entities;
using OnlineShop.Data.Enums;
using OnlineShop.Infrastructure.Interfaces;
using OnlineShop.Utilities.Dtos;

namespace OnlineShop.Application.Implementation
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<Product, int> _productRepository;
        private IRepository<Tag, string> _tagRepository;
        private IRepository<ProductTag, int> _productTagRepository;
        private IRepository<ProductQuantity, int> _productQuantityRepository;
        private IRepository<ProductImage, int> _productImageRepository;
        private IRepository<WholePrice, int> _wholePriceRepository;
        
        public ProductService(IUnitOfWork unitOfWork,
            IRepository<Product,int> productRepository,
            IRepository<Tag, string> tagRepository,
            IRepository<ProductTag, int> productTagRepository,
            IRepository<ProductQuantity, int> productQuantityRepository,
            IRepository<ProductImage, int> productImageRepository,
            IRepository<WholePrice, int> wholePriceRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _tagRepository = tagRepository;
            _productTagRepository = productTagRepository;
            _productQuantityRepository = productQuantityRepository;
            _productImageRepository = productImageRepository;
            _wholePriceRepository = wholePriceRepository;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public List<ProductViewModel> GetAll()
        {
            return _productRepository.FindAll().OrderBy(n => n.Name).ProjectTo<ProductViewModel>().ToList();
        }

        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _productRepository.FindAll(n=>n.Status == Status.Active);

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(n => n.Name.Contains(keyword) || n.Description.Contains(keyword));

            if (categoryId.HasValue)
                query = query.Where(n => n.CategoryId.Equals(categoryId));
            int totalRow = query.Count();

            query = query.OrderByDescending(n => n.DateCreated)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var productViewModels = query.ProjectTo<ProductViewModel>().ToList();

            return new PagedResult<ProductViewModel>()
            {
                Results = productViewModels,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
        }

        public ProductViewModel Add(ProductViewModel productVM)
        {
            var product = Mapper.Map<Product>(productVM);
            _productRepository.Add(product);
            return productVM;
        }

        public void Update(ProductViewModel productVM)
        {
            var product = Mapper.Map<Product>(productVM);
            _productRepository.Update(product);
        }

        public void Delete(int id)
        {
            _productRepository.Remove(id);
        }

        public ProductViewModel GetById(int id)
        {
            var product = _productRepository.FindById(id);
            return Mapper.Map<ProductViewModel>(product);
        }

        public void ImportExcel(string filePath, int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void AddQuantity(int productId, List<ProductQuantityViewModel> quantities)
        {
            _productQuantityRepository.RemoveMultiple(_productQuantityRepository.FindAll(x => x.ProductId == productId).ToList());
            foreach (var quantity in quantities)
            {
                _productQuantityRepository.Add(new ProductQuantity()
                {
                    ProductId = productId,
                    ColorId = quantity.ColorId,
                    SizeId = quantity.SizeId,
                    Quantity = quantity.Quantity
                });
            }
        }

        public List<ProductQuantityViewModel> GetQuantities(int productId)
        {
            return _productQuantityRepository.FindAll(x => x.ProductId == productId).ProjectTo<ProductQuantityViewModel>().ToList();
        }

        public void AddImages(int productId, string[] images)
        {
            _productImageRepository.RemoveMultiple(_productImageRepository.FindAll(x => x.ProductId == productId).ToList());
            foreach (var image in images)
            {
                _productImageRepository.Add(new ProductImage()
                {
                    Path = image,
                    ProductId = productId,
                    Caption = string.Empty
                });
            }
        }

        public List<ProductImageViewModel> GetImages(int productId)
        {
            return _productImageRepository.FindAll(x => x.ProductId == productId)
                .ProjectTo<ProductImageViewModel>().ToList();
        }

        public void AddWholePrice(int productId, List<WholePriceViewModel> wholePrices)
        {
            _wholePriceRepository.RemoveMultiple(_wholePriceRepository.FindAll(x => x.ProductId == productId).ToList());
            foreach (var wholePrice in wholePrices)
            {
                _wholePriceRepository.Add(new WholePrice()
                {
                    ProductId = productId,
                    FromQuantity = wholePrice.FromQuantity,
                    ToQuantity = wholePrice.ToQuantity,
                    Price = wholePrice.Price
                });
            }
        }

        public List<WholePriceViewModel> GetWholePrices(int productId)
        {
            return _wholePriceRepository.FindAll(x => x.ProductId == productId).ProjectTo<WholePriceViewModel>().ToList();
        }

        public List<ProductViewModel> GetLastest(int top)
        {
            return _productRepository.FindAll(n => n.Status == Status.Active)
                .OrderByDescending(n => n.DateCreated)
                .Take(top).ProjectTo<ProductViewModel>().ToList();
        }

        public List<ProductViewModel> GetHotProduct(int top)
        {
            return _productRepository.FindAll(n => n.Status == Status.Active && n.HotFlag.HasValue && n.HotFlag.Value)
                .OrderByDescending(n=>n.DateCreated)
                .Take(top)
                .ProjectTo<ProductViewModel>().ToList();
        }

        public List<ProductViewModel> GetRelatedProducts(int id, int top)
        {
            var product = _productRepository.FindById(id);
            return _productRepository.FindAll(n =>
                    n.Status == Status.Active && n.Id != id && n.CategoryId == product.CategoryId)
                .OrderByDescending(n => n.DateCreated)
                .Take(top)
                .ProjectTo<ProductViewModel>().ToList();
        }

        public List<ProductViewModel> GetUpsellProducts(int top)
        {
            return _productRepository.FindAll(n => n.Status == Status.Active
                                                   && n.PromotionPrice.HasValue
                                                   && n.PromotionPrice.Value > 0)
                .OrderByDescending(n => n.DateCreated)
                .Take(top)
                .ProjectTo<ProductViewModel>().ToList();
        }

        public List<TagViewModel> GetProductTags(int productId)
        {
            var tags = _tagRepository.FindAll();
            var productTags = _productTagRepository.FindAll();

            var query = from t in tags
                join pt in productTags
                    on t.Id equals pt.TagId
                where pt.ProductId == productId
                select new TagViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                };
            return query.ToList();
        }

        public bool CheckAvailability(int productId, int size, int color)
        {
            var quantity = _productQuantityRepository.FindSingle(x => x.ColorId == color && x.SizeId == size && x.ProductId == productId);
            if (quantity == null)
                return false;
            return quantity.Quantity > 0;
        }
    }
}