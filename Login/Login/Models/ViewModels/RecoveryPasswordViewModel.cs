﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Models.ViewModels
{
    public class RecoveryPasswordViewModel
    {
        public string token { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        public string Password2 { get; set; }
    }
}