using DB.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Common;
using DB.EF;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: Admin/Product


        #region --- Product category ----
        public ActionResult Index(string keySearch = "")
        {
            //lay du lieu tu DB->Dao->ProductCategoryDao
            ProductCategoryDao pcDao = new ProductCategoryDao();
            //lay tat ca
            var listPC = pcDao.GetAllProductCategories(keySearch);
            //chua co du lieu
            var model = new List<ProductCategoryModel>();

            foreach (var i in listPC)
            {
                var item = new ProductCategoryModel();
                item.Id = i.ID;
                item.Name = i.Name;
                item.CreatedBy = i.CreatedBy;
                item.CreatedDate = i.CreatedDate.HasValue ? i.CreatedDate.Value.ToShortDateString() : "";
                item.ModifiedDate = i.ModifiedDate.HasValue ? i.ModifiedDate.Value.ToShortDateString() : "";
                item.Status = i.Status;
                item.ModifiedBy = i.ModifiedBy;
                item.ImagePath = i.ImagePath;

                model.Add(item);
            }

            return View(model);
        }

        public ActionResult EditCategory(int id)
        {
            ProductCategoryDao pCDao = new ProductCategoryDao();
            var productCategory = pCDao.GetProductCategoryById(id);
            if (productCategory != null)
            {
                var model = new ProductCategoryModel();

                model.Id = productCategory.ID;
                model.Name = productCategory.Name;
                model.Status = productCategory.Status;
                model.ImagePath = productCategory.ImagePath;

                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        //sua danh muc san pham
        [HttpPost]
        public ActionResult EditCategory(ProductCategoryModel model, HttpPostedFileBase file)
        {
            if (model.Id != 0)
            {
                ProductCategoryDao pcDao = new ProductCategoryDao();
                var productCategory = pcDao.GetProductCategoryById(model.Id);
                productCategory.Name = model.Name;
                productCategory.Status = model.Status;
                productCategory.ModifiedDate = DateTime.Now;
                productCategory.ModifiedBy = Constants.Admin;

                if (file != null)
                {
                    string fileName = System.IO.Path.GetFileName(file.FileName);
                    var filePath = "/Content/Images/" + fileName;
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    file.SaveAs(path);
                    model.ImagePath = filePath;
                    productCategory.ImagePath = model.ImagePath;
                }

                pcDao.UpdateProductCategory(productCategory);
            }

            return RedirectToAction("Index");
        }

        public ActionResult AddCategory()
        {
            var model = new ProductCategoryModel();
            model.Status = true;
            return View(model);
        }

        //them danh muc san pham
        [HttpPost]
        public ActionResult AddCategory(ProductCategoryModel model, HttpPostedFileBase file)
        {
            var productCategory = new ProductCategory();
            productCategory.Name = model.Name;
            productCategory.Status = model.Status;
            productCategory.CreatedDate = DateTime.Now;
            productCategory.CreatedBy = Constants.Admin;

            if (file != null)
            {
                string fileName = System.IO.Path.GetFileName(file.FileName);
                var filePath = "/Content/Images/" + fileName;
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                file.SaveAs(path);
                model.ImagePath = filePath;
                productCategory.ImagePath = model.ImagePath;
            }

            ProductCategoryDao pcDao = new ProductCategoryDao();
            pcDao.UpdateProductCategory(productCategory);

            return RedirectToAction("Index");
        }

        #endregion


    }
}