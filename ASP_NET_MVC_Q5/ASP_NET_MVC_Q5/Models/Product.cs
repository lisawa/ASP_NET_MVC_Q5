﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC_Q5.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public string Product_Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Create_Date { get; set; }

        public string ShowCreateDate
        {
            get
            {
                return Create_Date.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}