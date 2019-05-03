using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ASP_NET_MVC_Q5.Interface;
using ASP_NET_MVC_Q5.Models;
using Newtonsoft.Json;

namespace ASP_NET_MVC_Q5.Repository
{
    public class ProductRepo: IProductRepo
    {
        public List<Product> GetAll()
        {
            string json = string.Empty;

            using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~/Models/data.json")))
            {
                json = r.ReadToEnd();
            }

            var product = JsonConvert.DeserializeObject<List<Product>>(json);

            return product;
        }


        public List<Product> SearchFor(string name, string locate, decimal? maxPrice, decimal? minPrice = 0) {
            var products = GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(x => x.Product_Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            if (!string.IsNullOrEmpty(locate))
            {
                products = products.Where(x => x.Locale == locate).ToList();
            }

            if (maxPrice != null)
            {
                products = products.Where(x => x.Price <= maxPrice).ToList();
            }

            if(minPrice != null)
            {
                products = products.Where(x => x.Price >= minPrice).ToList();
            }
            
            return products;
        }
    }
}