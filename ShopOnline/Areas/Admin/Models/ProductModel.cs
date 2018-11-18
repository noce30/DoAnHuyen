using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            this.Categories = new List<SelectListItem>();
        }
        public long Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string Name { get; set; }

        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục sản phẩm")]
        public long CategoryId { get; set; }

        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả sản phẩm")]
        public string Descriptions { get; set; }

        public bool Status { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}