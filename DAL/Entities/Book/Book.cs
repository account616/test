using System.Collections.Generic;

namespace DAL.Entities.Book
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }

        public Genre.Genre Genre{ get; set; }
        public Language.Language Language { get; set; }

        public List<Author.Author> Authors { get; set; }
    }
}
