using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Models.ViewModels
{
    public class SaleData
    {
        [Display(Name = "Client")]
        [Required]
        public int saleClientId { get; set; }

        [Display(Name = "Vendor")]
        [Required]
        public int saleVendorId { get; set; }

        [Display(Name = "Discount")]
        public decimal saleDiscount { get; set; }

        [Display(Name = "Total")]
        [Required]
        public decimal saleTotal { get; set; }
    }
}