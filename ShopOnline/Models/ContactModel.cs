using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class ContactModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
            set { }
        }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage ="Email address is required.")]
        [EmailAddress(ErrorMessage ="Please enter email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }
    }
}