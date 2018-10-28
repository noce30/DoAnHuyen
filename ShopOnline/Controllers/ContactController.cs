using DB.DAO;
using DB.EF;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactModel model)
        {
            if(ModelState.IsValid)
            {
                ContactDao contactDao = new ContactDao();
                Feedback fb = new Feedback();

                //chuyen doi data from model to feedback 
                fb.Name = model.FullName;
                fb.Phone = model.PhoneNumber;
                fb.Email = model.Email;
                fb.Content = model.Content;
                fb.Address = model.Address;
                fb.Status = true;
                fb.CreatedDate = DateTime.Now;
                
                contactDao.Insert(fb);
                ViewBag.SuccessMessage = "Your submission is successfully";
            }

            return View();
        }
    }
}