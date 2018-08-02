using DAL.Entities.Author;
using DAL.Entities.Book;
using DAL.Entities.Genre;
using DAL.Entities.Language;
using SL.Messages.Books;
using System.Collections.Generic;

namespace SL.Mappings
{
    public static class BookMapper
    {
        public static Book ConvertToBook(this CreateBookRequest createRequest)
        {
            Book book = new Book();
            book.Title = createRequest.Title;
            book.ISBN = createRequest.ISBN;
            book.Description = createRequest.Description;
            book.Genre = new Genre() { GenreId = createRequest.GenreId };
            book.Language = new Language() { LanguageId = createRequest.LanguageId };
            book.Authors = new List<Author>();
            foreach (int id in createRequest.AuthorIds)
                book.Authors.Add(new Author() { AuthorId = id });

            return book;
        }

        public static Book ConvertToBook(this UpdateBookRequest updateRequest)
        {
            Book book = new Book();
            book.BookId = updateRequest.BookId;
            book.Title = updateRequest.Title;
            book.ISBN = updateRequest.ISBN;
            book.Description = updateRequest.Description;
            book.Genre = new Genre() { GenreId = updateRequest.GenreId };
            book.Language = new Language() { LanguageId = updateRequest.LanguageId };
            book.Authors = new List<Author>();
            foreach (int id in updateRequest.AuthorIds)
                book.Authors.Add(new Author() { AuthorId = id });

            return book;
        }
    }
}
