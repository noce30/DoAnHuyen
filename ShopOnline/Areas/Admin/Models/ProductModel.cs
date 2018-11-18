using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            this.Categories = new List<ProductCategoryModel>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public string Descriptions { get; set; }
        public bool Status { get; set; }
        public List<ProductCategoryModel> Categories { get; set; }
    }
}