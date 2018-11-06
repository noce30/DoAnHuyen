using DB.DAO;
using DB.EF;
using ShopOnline.Models;
using ShopOnline.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new HomeModel();

            ProductDao productDao = new ProductDao();
            ProductCategoryDao productCategoryDao = new ProductCategoryDao();

            var listCategories = productCategoryDao.GetAllActiveProductCategories();
            foreach (var item in listCategories)
            {
                var products = productDao.GetProductsByCategory(item.ID).Take(4).ToList();
                var categories = converToProductCategories(products, item);
                model.Categories.Add(categories);
            }
            
            return View(model);
        }
        //convert ProductCategory tu csdl vao model ProductCategoryModel
        #region--Private----
        private ProductCategoryModel convertCategoryToCategoryModel(ProductCategory productCategory)
        {
            //chuyen doi du lieu tu DB sang model (file Models/Products)
            var model = new ProductCategoryModel();
            //lay Id trong csdl
            model.Id = productCategory.ID;
            //lay name trong csdl
            model.Name = productCategory.Name;

            return model;
        }

        private ProductItemModel convertProductToProductItemModel(Product product)
        {
            var model = new ProductItemModel();
            model.Id = product.ID;
            model.ImageURL = product.Image;
            model.Price = product.Price.Value;
            model.Title = product.Name;

            return model;
        }

        private List<ProductItemModel> convertProductsToListProductModel(List<Product> products)
        {
            var model = new List<ProductItemModel>();
            foreach (var item in products)
            {
                var productItem = convertProductToProductItemModel(item);
                
                model.Add(productItem);
            }

            return model;
        }

        private ProductCategories converToProductCategories(List<Product> products, ProductCategory productCategory)
        {
            var model = new ProductCategories();
            model.Category = convertCategoryToCategoryModel(productCategory);
            if(products.Count > 0)
            {
                model.Products = convertProductsToListProductModel(products);
            }

            return model;
        }
        #endregion
    }
}