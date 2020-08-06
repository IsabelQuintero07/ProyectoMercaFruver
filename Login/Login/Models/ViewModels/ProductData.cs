using System.ComponentModel.DataAnnotations;

namespace Login.Models.ViewModels
{
    public class ProductData
    {
        [Required]
        [Display(Name = "Category")]
        public int productCategoryId { get; set; }
        [Required]
        [Display(Name = "Code")]
        public int productCode { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string productName { get; set; }
        [Required]
        [Display(Name = "Selling Price")]
        public decimal productSellingPrice { get; set; }
        [Required]
        [Display(Name = "Stock")]
        public int productStock { get; set; }

        [Required]
        [Display(Name = "Cost")]
        public decimal productCost { get; set; }

        //public virtual Category Category { get; set; }

    }

    public class ProductEditData
    {
        public int productId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int productCategoryId { get; set; }
        [Required]
        [Display(Name = "Code")]
        public int productCode { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string productName { get; set; }
        [Required]
        [Display(Name = "Selling Price")]
        public decimal productSellingPrice { get; set; }
        [Required]
        [Display(Name = "Stock")]
        public int productStock { get; set; }

        [Display(Name = "Limit Stock")]
        public int productStockLimit { get; set; }

        [Required]
        [Display(Name = "Cost")]
        public decimal productCost { get; set; }

        //public virtual ProductEditData Product { get; set; }
    }
}