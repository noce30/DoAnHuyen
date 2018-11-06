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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _ProductItem(ProductItemModel model)
        {
            return PartialView(model);
        }

        public ActionResult Detail(int productId)
        {
            ProductDao productDao = new ProductDao();

            var product = productDao.GetProductById(productId);

            // chuyen doi dl tu db sang model de hien thi
            var model = new ProductItemModel();
            model.Id = product.ID;
            model.Title = product.Name;
            model.Price = product.Price ?? 0;//co the co gia tr hoac khong ? neu co gia tri thi hien gt ? nguoc lai hien thi 0
            model.ImageURL = product.Image;
            model.Description = product.Descriptions;

            return View(model);
        }

        public ActionResult ProductCategory(int productCategoryId)
        {
            var productCategoryDao = new ProductCategoryDao();
            var productDao = new ProductDao();

            var category = productCategoryDao.GetProductCategoryById(productCategoryId);
            var listProducts = productDao.GetProductsByCategory(productCategoryId);

            var model = new ProductCategories();
            model = converToProductCategories(listProducts, category);

            return View(model);
        }

        #region--Private----
        private ProductCategoryModel convertCategoryToCategoryModel(ProductCategory productCategory)
        {
            var model = new ProductCategoryModel();
            model.Id = productCategory.ID;
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
            if (products.Count > 0)
            {
                model.Products = convertProductsToListProductModel(products);
            }

            return model;
        }
        #endregion
    }
}