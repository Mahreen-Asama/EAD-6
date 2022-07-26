﻿using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Core_Identity.ViewModels
{
    public class RegisterViewModel
    {
        //I have added, List of Genders and initialised it in the constructor with
        //some default value. I did it because I need to show these Gender values
        //against Radio buttons in view, so I initialize it here.
        public RegisterViewModel()
        {
            Genders = new List<string>() { "Male", "Female", "Others" };

            //Genders = new List<string>() { new string("Male"), new string("Female"), new string("Others") };
        }

        [Required]
        [StringLength(20, ErrorMessage = "Length should not exceed 20 characters")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password must match with sconfirmation password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Gender { get; set; }
        public List<string> Genders { get; set; }
    }
}
