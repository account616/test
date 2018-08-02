using System.ComponentModel.DataAnnotations;

namespace PL.Models.ViewModels
{
    public class AuthorViewModel
    {
        public int? AuthorId { get; set; }
        [Required(ErrorMessage = "Ime mora biti uneto")]
        [StringLength(50, ErrorMessage = "Ime mora biti manje od 30 karaktera")]
        public string Name { get; set; }
        public NationalityViewModel Nationality { get; set; }
    }
}