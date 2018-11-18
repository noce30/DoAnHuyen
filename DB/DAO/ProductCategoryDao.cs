using DB.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DAO
{
    public class ProductCategoryDao
    {
        ShopOnlineContext db = null;
        public ProductCategoryDao()
        {
            db = new ShopOnlineContext();
        }

        public List<ProductCategory> GetAllActiveProductCategories()
        {
            var result = db.ProductCategories.Where(x => x.Status).ToList();
            return result;
        }
        // tra ve productCategory.
        // truy van db cua ProductCategories lay dong dau tien thoa man dieu kien trong sql ProductCategories
        public ProductCategory GetProductCategoryById(long id)
        {
            var result = db.ProductCategories.FirstOrDefault(x => x.ID == id);
            return result;
        }

        public List<ProductCategory> GetAllProductCategories(string KeySearch = "")
        {
            //lay tat ca product category tu db (ToList: lay ra List)
            var result = db.ProductCategories.AsQueryable();
            if (KeySearch != "")
            {
                result = result.Where(x => x.Name.ToLower().Contains(KeySearch.ToLower()));
            }

            return result.ToList();
        }

        public void UpdateProductCategory(ProductCategory productCategory)
        {
            db.ProductCategories.AddOrUpdate(productCategory);
            db.SaveChanges();
        }

        public void AddProductCategory(ProductCategory productCategory)
        {
            db.ProductCategories.Add(productCategory);
            db.SaveChanges();
        }
    }
}
