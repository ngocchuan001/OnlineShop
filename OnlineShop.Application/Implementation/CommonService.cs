using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Common;
using OnlineShop.Data.Entities;
using OnlineShop.Infrastructure.Interfaces;
using OnlineShop.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Application.Implementation
{
    public class CommonService : ICommonService
    {
        private IRepository<Slide, int> _slideRepository;
        private IRepository<Footer, string> _footerRepository;
        private IRepository<SystemConfig, string> _systemConfigRepository;
        private IUnitOfWork _unitOfWork;

        public CommonService(IRepository<Slide, int> slideRepository, IRepository<Footer, string> footerRepository, IRepository<SystemConfig, string> systemConfigRepository, IUnitOfWork unitOfWork)
        {
            _slideRepository = slideRepository;
            _footerRepository = footerRepository;
            _systemConfigRepository = systemConfigRepository;
            _unitOfWork = unitOfWork;
        }
        public FooterViewModel GetFooter()
        {
            return Mapper.Map<Footer, FooterViewModel>(_footerRepository.FindSingle(x => x.Id ==
            CommonConstants.DefaultFooterId));
        }

        public List<SlideViewModel> GetSlides(string groupAlias)
        {
            return _slideRepository.FindAll(x => x.Status && x.GroupAlias == groupAlias)
                .ProjectTo<SlideViewModel>().ToList();
        }

        public SystemConfigViewModel GetSystemConfig(string code)
        {
            return Mapper.Map<SystemConfig, SystemConfigViewModel>(_systemConfigRepository.FindSingle(x => x.Id == code));
        }
    }
}
