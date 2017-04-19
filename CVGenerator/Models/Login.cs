using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [StringLength(6, ErrorMessage = "Password must be more than 6 charactes")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}