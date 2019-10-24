using kpsUowRmqTest.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpsUowRmqTest.Web.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        //private readonly IUnitOfWork _unitOfWork;
        //public MenuViewComponent(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
        public IViewComponentResult Invoke()
        {
            //var menu = _unitOfWork.LeftMenuRepository.Get();
            //return View(menu);
            return View();
        }
    }
}
