using System.ComponentModel.DataAnnotations;

namespace Login.Models.ViewModels
{
    public class ConceptData
    {
        [Required]
        [Display(Name = "Product")]
        public int conceptProductId { get; set; }


        [Required]
        [Display(Name = "Sale")]
        public int conceptSaleId { get; set; }


        [Required]
        [Display(Name = "Quantity")]
        public int conceptQuantity { get; set; }


        [Required]
        [Display(Name = "Unit Price")]
        public decimal conceptUnitPrice { get; set; }
    }
}