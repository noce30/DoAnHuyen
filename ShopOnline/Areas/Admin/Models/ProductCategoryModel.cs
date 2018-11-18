using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Models
{
    public class ProductCategoryModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public bool Status { get; set; }

        public string ImagePath { get; set; }

    }
}