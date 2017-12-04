using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerceWeb.Models {
    public class Login {
        public string Email { get; set; }
        //[ValidatePasswordLength]
        [DataType(DataType.Password)]
        //[Display(Name = "Password")]
        public string Password { get; set; }

        public bool rememberMe { get; set; }
    }
}