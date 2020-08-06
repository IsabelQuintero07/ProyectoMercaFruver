using System.ComponentModel.DataAnnotations;

namespace Login.Models.ViewModels
{
    public class ClientData
    {
        [Display(Name = "Document Type")]
        [Required]
        public int clientDocumentTypeId { get; set; }

        [Display(Name = "Document Number")]
        [Required]
        public string clientDocumentNumber { get; set; }


        [Display(Name = "Name")]
        [Required]
        public string clientName { get; set; }


        [Display(Name = "Address")]
        [Required]
        public string clientAddress { get; set; }


        [Display(Name = "Email")]
        [Required]
        public string clientEmail { get; set; }


        [Display(Name = "Phone")]
        [Required]
        public string clientPhoneNumber { get; set; }
    }
}