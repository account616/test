using System.ComponentModel.DataAnnotations;

namespace PL.Models.ViewModels
{
    public class LanguageViewModel
    {
        public int? LanguageId { get; set; }
        [Display(Name = "Jezik")]
        [Required(ErrorMessage = "Jezik mora biti unet")]
        [StringLength(30, ErrorMessage = "Tekst mora biti manji od 30 karaktera")]
        public string Language { get; set; }
    }
}