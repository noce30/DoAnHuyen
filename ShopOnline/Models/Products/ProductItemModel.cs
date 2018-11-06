using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models.Products
{
    public class ProductItemModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}