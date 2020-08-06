using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Models.ViewModels
{
    public class CreateUserViewModel
    {
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

    }
}