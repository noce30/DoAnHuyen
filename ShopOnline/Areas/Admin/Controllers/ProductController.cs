using DB.DAO;
using DB.EF;
using ShopOnline.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string keySearch = "")
        {
            ProductDao productDao = new ProductDao();
            ProductCategoryDao pcDao = new ProductCategoryDao();
            var listProducts = productDao.GetAll(keySearch);
            var model = new List<ProductModel>();

            // chuyen doi product qua product model
            foreach (var item in listProducts)
            {
                var modelItem = new ProductModel();
                var category = pcDao.GetProductCategoryById(item.CategoryID);
                modelItem = mapProductToProductModel(item);
                modelItem.CategoryName = category.Name;
                model.Add(modelItem);
            }
            return View(model);
        }

        public ActionResult EditProduct(int id)
        {
            if(id > 0)
            {
                ProductDao productDao = new ProductDao();
                ProductCategoryDao pcDao = new ProductCategoryDao();
                var product = productDao.GetProductById(id);
                if(product !=null)
                {
                    var model = mapProductToProductModel(product);
                    var categories = pcDao.GetAllProductCategories();
                    model.Categories = prepareCategories(categories);
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditProduct(ProductModel model)
        {

            return View(model);
        }

        private ProductModel mapProductToProductModel(Product product)
        {
            var model = new ProductModel();
            model.Id = product.ID;
            model.Name = product.Name;
            model.Price = product.Price.HasValue ? product.Price.Value : 0;
            model.Descriptions = product.Descriptions;
            model.Status = product.Status;
            model.ImageURL = product.Image;

            return model;
        }

        private List<ProductCategoryModel> prepareCategories(List<ProductCategory> categories)
        {
            var model = new List<ProductCategoryModel>();
            foreach (var item in categories)
            {
                var modelItem = new ProductCategoryModel();
                modelItem.Id = item.ID;
                modelItem.Name = item.Name;
                model.Add(modelItem);
            }

            return model;
        }
    }
}