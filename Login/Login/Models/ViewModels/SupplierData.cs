using System.ComponentModel.DataAnnotations;

namespace Login.Models.ViewModels
{
    public class SupplierData
    {
        [Required]
        [Display(Name = "Nit")]
        public int supplierNit { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string supplierName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string supplierAddress { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string supplierPhoneNumber { get; set; }

        [Required]
        [Display(Name = "City")]
        public string supplierCity { get; set; }

        [Required]
        [Display(Name = "Web Page")]
        [DataType(DataType.Url)]
        public string supplierWebpage { get; set; }
    }
}