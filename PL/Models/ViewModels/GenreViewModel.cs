using System.ComponentModel.DataAnnotations;

namespace PL.Models.ViewModels
{
    public class GenreViewModel
    {
        public int? GenreId { get; set; }
        [Display(Name = "Žanra")]
        [Required(ErrorMessage = "Žanr mora biti unet")]
        [StringLength(30, ErrorMessage = "Tekst mora biti manji od 30 karaktera")]
        public string Genre { get; set; }
    }
}