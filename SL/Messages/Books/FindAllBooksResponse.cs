using DAL.Entities.Book;
using System.Collections.Generic;

namespace SL.Messages.Books
{
    public class FindAllBooksResponse : ResponseBase
    {
        public List<Book> Books { get; set; }
    }
}
