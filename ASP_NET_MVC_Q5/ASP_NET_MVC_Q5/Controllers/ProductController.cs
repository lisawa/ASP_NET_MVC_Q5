using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC_Q5.Models;
using ASP_NET_MVC_Q5.Repository;

namespace ASP_NET_MVC_Q5.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(ProductViewModel vm)
        { 
            if (vm.ResetTag)
            {
                vm = new ProductViewModel();
                ModelState.Clear();
            }

            var newvm = new ProductViewModel
            {
                Products = new ProductRepo().SearchFor(vm.SearchName, vm.SearchLocate, vm.SearchMaxPrice, vm.SearchMinPrice),
                SearchName = vm.SearchName,
                SearchLocate = vm.SearchLocate,
                SearchMinPrice = vm.SearchMinPrice,
                SearchMaxPrice = vm.SearchMaxPrice,
                Page = vm.Page == 0 ? 0 : vm.Page,
                PageSize = vm.PageSize == 0 ? 5 : vm.Page,
                Locate = SetLocateList()
            };

            var itemCount = newvm.Products != null ? newvm.Products.Count() : 0;
            newvm.TotalPage = Math.Ceiling((decimal)itemCount / newvm.PageSize);
            newvm.Products = newvm.Products.Skip(newvm.Page * newvm.PageSize).Take(newvm.PageSize).ToList();
            
            return View(newvm);
        }

        public List<SelectListItem> SetLocateList()
        {
            var list = Enum.GetValues(typeof(Locate)).Cast<Locate>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = v.ToString(),
            }).ToList();

            list.Insert(0, new SelectListItem()
            {
                Text = "",
                Value = ""
            });

            return list;
        }
    }
}