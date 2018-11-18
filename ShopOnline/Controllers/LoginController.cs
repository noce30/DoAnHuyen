using DB.DAO;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var userDao = new UserDao();
                if (userDao.Login(model.UserName, model.Password))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    model.UserName = string.Empty;
                    model.Password = string.Empty;
                    ViewBag.errorMessage = "Account not exist.";
                    return View(model);
                }
            }

            return View(model);
        }
    }
}