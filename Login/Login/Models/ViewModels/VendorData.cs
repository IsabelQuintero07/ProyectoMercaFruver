using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Models.ViewModels
{
    public class VendorData
    {
        [Required]
        [Display(Name = "Document Type")]
        public int vendorDocumentTypeId { get; set; }
        [Required]
        [Display(Name = "Document Number")]
        public string vendorDocumentTypeNumber { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string vendorName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string vendorAddress { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string vendorEmail { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string vendorPhoneNumber { get; set; }
    }
}