using System.ComponentModel.DataAnnotations;

namespace PL.Models.ViewModels
{
    public class NationalityViewModel
    {
        public int NationalityId { get; set; }
        [Display(Name = "Nacionalnost")]
        [Required(ErrorMessage = "Nacionalnost mora biti uneta")]
        [StringLength(30, ErrorMessage = "Tekst mora biti manji od 30 karaktera")]
        public string Nationality { get; set; }
    }
}