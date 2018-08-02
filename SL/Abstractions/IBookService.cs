using SL.Messages.Books;

namespace SL.Abstractions
{
    public interface IBookService
    {
        CreateBookResponse CreateBook(CreateBookRequest request);
        FindAllBooksResponse FindAllBooks();
        UpdateBookResponse UpdateBook(UpdateBookRequest request);
        DeleteBookResponse DeleteBook(DeleteBookRequest request);
    }
}
