using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Data.Entities;
using OnlineShop.Infrastructure.Interfaces;

namespace OnlineShop.Application.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private IRepository<ProductCategory, int> _productCategoryRepository;

        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IRepository<ProductCategory, int> productCategoryRepository,
            IUnitOfWork unitOfWork)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }
        

        public ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm)
        {
            var productCategory = Mapper.Map<ProductCategory>(productCategoryVm);
            _productCategoryRepository.Add(productCategory);
            return productCategoryVm;
        }

        public void Update(ProductCategoryViewModel productCategoryVm)
        {
            var productCategory = Mapper.Map<ProductCategory>(productCategoryVm);
            _productCategoryRepository.Update(productCategory);
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Remove(id);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryRepository.FindAll()
                .OrderBy(n => n.ParentId)
                .ProjectTo<ProductCategoryViewModel>().ToList();
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            return _productCategoryRepository.FindAll(n => n.Name.Contains(keyword) || n.Description.Contains(keyword))
                .OrderBy(n => n.ParentId)
                .ProjectTo<ProductCategoryViewModel>().ToList();
        }

        public List<ProductCategoryViewModel> GetAllByParentId(int parentId)
        {
            return _productCategoryRepository.FindAll(n => n.ParentId == parentId)
                .OrderBy(n => n.Name)
                .ProjectTo<ProductCategoryViewModel>().ToList();
        }

        public ProductCategoryViewModel GetById(int id)
        {
            var productCategory = _productCategoryRepository.FindById(id);
            return Mapper.Map<ProductCategoryViewModel>(productCategory);
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            var sourceCategory = _productCategoryRepository.FindById(sourceId);
            sourceCategory.ParentId = targetId;
            _productCategoryRepository.Update(sourceCategory);

            //Get all sibling
            var sibling = _productCategoryRepository.FindAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _productCategoryRepository.Update(child);
            }
        }

        public void ReOrder(int sourceId, int targetId)
        {
            var source = _productCategoryRepository.FindById(sourceId);
            var target = _productCategoryRepository.FindById(targetId);
            int tempOrder = source.SortOrder;
            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _productCategoryRepository.Update(source);
            _productCategoryRepository.Update(target);
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            return _productCategoryRepository.FindAll(n => n.HomeFlag.HasValue && n.HomeFlag.Value)
                .OrderBy(n => n.HomeOrder)
                .ProjectTo<ProductCategoryViewModel>().ToList();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}