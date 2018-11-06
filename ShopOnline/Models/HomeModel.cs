using ShopOnline.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class HomeModel
    {
        public HomeModel()
        {
            this.Categories = new List<ProductCategories>();
        }

        public List<ProductCategories> Categories { get; set; }
    }
    //
    public class ProductCategories
    {
        public ProductCategories()
        {
            this.Products = new List<ProductItemModel>();
            this.Category = new ProductCategoryModel();
        }
        //danh sach sp theo category(the loai)  
        public List<ProductItemModel> Products { get; set; }

        public ProductCategoryModel Category { get; set; }
    }
}