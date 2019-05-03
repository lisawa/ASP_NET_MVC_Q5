using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q5.Models
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }

        public bool ResetTag { get; set; }

        public int Page { get; set; }

        public decimal TotalPage { get; set; }

        public int PageSize { get; set; }

        public List<SelectListItem> Locate { get; set; }

        public string SearchName { get; set; }

        public decimal? SearchMinPrice { get; set; }
        public decimal? SearchMaxPrice { get; set; }
        public string SearchLocate { get; set; }
    }
}