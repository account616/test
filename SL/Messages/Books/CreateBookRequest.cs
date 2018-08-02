using DAL.Entities.Author;
using DAL.Entities.Genre;
using DAL.Entities.Language;
using System.Collections.Generic;

namespace SL.Messages.Books
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public int LanguageId { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
