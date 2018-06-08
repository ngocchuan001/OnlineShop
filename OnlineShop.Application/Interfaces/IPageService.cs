using OnlineShop.Application.ViewModels.Blog;
using OnlineShop.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Interfaces
{
    public interface IPageService
    {
        void Add(PageViewModel pageVm);

        void Update(PageViewModel pageVm);

        void Delete(int id);

        List<PageViewModel> GetAll();

        PagedResult<PageViewModel> GetAllPaging(string keyword, int page, int pageSize);

        PageViewModel GetByAlias(string alias);

        PageViewModel GetById(int id);

        void SaveChanges();

    }
}
