using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Login.Models.ViewModels
{
    public class SaleViewModel
    {
        [Display(Name = "Client")]
        [Required]
        public int saleClientId { get; set; }

        [Display(Name = "Vendor")]
        [Required]
        public int saleVendorId { get; set; }

        //[Display(Name = "Discount")]
        //[Required]
        //public decimal saleDiscount{ get; set; }

        public List<Concept> Concepts { get; set; }

    }
    public class Concept
    {
        public int conceptProductId { get; set; }
        public int conceptQuantity { get; set; }
        public decimal conceptUnitPrice { get; set; }
    }
}