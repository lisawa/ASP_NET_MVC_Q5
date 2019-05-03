using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_NET_MVC_Q5.Models;

namespace ASP_NET_MVC_Q5.Interface
{
    interface IProductRepo
    {
        List<Product> GetAll();

        List<Product> SearchFor(string name, string locate, decimal? maxPrice, decimal? minPrice);
    }
}
