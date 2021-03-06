﻿using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [MinLength(6, ErrorMessage = "Password must be more than 6 charactes")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Password confirmation")]
        [Compare("Password", ErrorMessage = "Password confirmation is not corrrect")]
        public string PasswordConfirmation { get; set; }
    }
}