using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class LoginModel
    {
        [EmailAddress(ErrorMessage = "Your user name should be an email.")]
        [Required(ErrorMessage = "Please enter your user name.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}