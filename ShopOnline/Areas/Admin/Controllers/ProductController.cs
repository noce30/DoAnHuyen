using DB.DAO;
using DB.EF;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Common;
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
            if (id > 0)
            {
                ProductDao productDao = new ProductDao();
                var product = productDao.GetProductById(id);
                if (product != null)
                {
                    var model = mapProductToProductModel(product);
                    model.Categories = getCategoriesSelectList(product.CategoryID);
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditProduct(ProductModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                ProductDao pcDao = new ProductDao();
                var product = pcDao.GetProductById(model.Id);
                product.Name = model.Name;
                product.Status = model.Status;
                product.CategoryID = model.CategoryId;
                product.Descriptions = model.Descriptions;
                product.Price = model.Price;
                product.ModifiedDate = DateTime.Now;
                product.ModifiedBy = Constants.Admin;

                if (file != null)
                {
                    string fileName = System.IO.Path.GetFileName(file.FileName);
                    var filePath = "/Content/Images/" + fileName;
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    file.SaveAs(path);
                    model.ImageURL = filePath;
                    product.Image = model.ImageURL;
                }

                pcDao.UpdateProduct(product);

                return RedirectToAction("Index");
            }

            model.Categories = getCategoriesSelectList(model.CategoryId);
            return View(model);
        }

        public ActionResult AddProduct()
        {
            var model = new ProductModel();
            model.Categories = getCategoriesSelectList(0);
            model.Status = true;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var productDao = new ProductDao();
                var product = new Product();
                product.Name = model.Name;
                product.Status = model.Status;
                product.CategoryID = model.CategoryId;
                product.Descriptions = model.Descriptions;
                product.Price = model.Price;
                product.CreateDate = DateTime.Now;
                product.CreateBy = Constants.Admin;

                if (file != null)
                {
                    string fileName = System.IO.Path.GetFileName(file.FileName);
                    var filePath = "/Content/Images/" + fileName;
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    file.SaveAs(path);
                    model.ImageURL = filePath;
                    product.Image = model.ImageURL;
                }

                productDao.AddProduct(product);

                return RedirectToAction("Index");
            }

            model.Categories = getCategoriesSelectList(0);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            var productDao = new ProductDao();
            var product = productDao.GetProductById(productId);
            if(product!=null)
            {
                productDao.DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }

        private ProductModel mapProductToProductModel(Product product)
        {
            var model = new ProductModel();
            model.Id = product.ID;
            model.Name = product.Name;
            model.Price = product.Price.HasValue ? product.Price.Value : 0;
            model.Descriptions = product.Descriptions;
            model.CategoryId = product.CategoryID;
            model.Status = product.Status;
            model.ImageURL = product.Image;

            return model;
        }

        private IEnumerable<SelectListItem> getCategoriesSelectList(long categoryId)
        {
            ProductCategoryDao pcDao = new ProductCategoryDao();
            var categories = pcDao.GetAllProductCategories();
            return categories.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.ID.ToString(),
                                      Selected = x.ID == categoryId
                                  });
        }
    }
}