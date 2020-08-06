using System.ComponentModel.DataAnnotations;

namespace Login.Models.ViewModels
{
    public class PurchaseData
    {
        [Required]
        [Display(Name = "Supplier")]
        public int purchaseSupplierId { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int purchaseProductId { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int purchaseQuantity { get; set; }

        [Required]
        [Display(Name = "Unit Cost")]
        public decimal purchaseUnitCost { get; set; }
    }
}