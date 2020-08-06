using System.ComponentModel.DataAnnotations;

namespace Login.Models.ViewModels
{
    public class CategoryData
    {
        public int categoryId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string categoryName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string categoryDescription { get; set; }


    }
}