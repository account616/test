using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PL.Models.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        [Display(Name = "Naslov")]
        [Required(ErrorMessage = "Naslov mora biti unet")]
        [StringLength(50, ErrorMessage = "Naslov mora biti kraći od 50 karaktera")]
        public string Title { get; set; }
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Zanr")]
        public GenreViewModel Genre { get; set; }
        [Required(ErrorMessage = "Jezik mora biti odabran")]
        [Display(Name = "Jezik")]
        public LanguageViewModel Language { get; set; }
        [Required(ErrorMessage = "Autor mora biti odabran")]
        public List<int> AuthorIds { get; set; }
        [Display(Name = "Autori")]
        public List<AuthorViewModel> Authors { get; set; }
    }
}