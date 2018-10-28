using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email Address should be not empty.")]
        [EmailAddress(ErrorMessage = "Email Address should be an email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password should be not empty.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword should be not empty.")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get {
                return $"{this.FirstName} {this.LastName}";
            } set { } }
    }
}