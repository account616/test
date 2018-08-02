using System;
using DAL.Entities.Book;
using SL.Abstractions;
using SL.Messages.Books;
using SL.Mappings;

namespace SL.Implementations
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository repository)
        {
            _bookRepository = repository;
        }

        public CreateBookResponse CreateBook(CreateBookRequest request)
        {
            CreateBookResponse response = new CreateBookResponse();
            try
            {
                Book book = request.ConvertToBook();
                _bookRepository.Create(book);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public DeleteBookResponse DeleteBook(DeleteBookRequest request)
        {
            DeleteBookResponse response = new DeleteBookResponse();
            try
            {
                _bookRepository.Delete(request.BookId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public FindAllBooksResponse FindAllBooks()
        {
            FindAllBooksResponse response = new FindAllBooksResponse();
            try
            {
                response.Books = _bookRepository.Read();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public UpdateBookResponse UpdateBook(UpdateBookRequest request)
        {
            UpdateBookResponse response = new UpdateBookResponse();
            try
            {
                Book book = request.ConvertToBook();
                _bookRepository.Update(book);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
