using DB.DAO;
using DB.EF;
using ShopOnline.Common;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.Password.Equals(model.ConfirmPassword))
                {
                    UserDao userDao = new UserDao();
                    User user = new User();

                    //check user existing
                    if (userDao.CheckUserExist(model.UserName))
                    {
                        ViewBag.UserExistError = "UserName already exist.";
                    }
                    else
                    {
                        //map regiter model to user entity
                        user.Name = model.FullName;
                        user.UserName = model.UserName;
                        user.Address = model.Address;
                        user.PassWord = model.Password;
                        user.Status = true;
                        user.Phone = model.PhoneNumber;
                        user.CreateBy = Constants.Admin;
                        user.CreateDate = DateTime.Now;

                        userDao.Insert(user);
                        ViewBag.Error = string.Empty;

                        return RedirectToAction("Index", "Login");
                    }               
                }
                else
                {
                    ViewBag.Error = "Password not match.";
                }
            }

            return View(model);
        }
    }
}