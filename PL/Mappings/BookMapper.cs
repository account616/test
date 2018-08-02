using DAL.Entities.Book;
using PL.Models.ViewModels;
using SL.Messages.Books;
using System;
using System.Collections.Generic;

namespace PL.Mappings
{
    public static class BookMapper
    {
        public static BookViewModel ConvertToBookViewModel(this Book book)
        {
            BookViewModel bookViewModel = new BookViewModel();
            bookViewModel.BookId = book.BookId;
            bookViewModel.Title = book.Title;
            bookViewModel.ISBN = book.ISBN;
            bookViewModel.Description = book.Description;
            bookViewModel.Language = book.Language.ConvertToLanguageViewModel();
            bookViewModel.Genre = book.Genre.ConvertToGenreViewModel();
            bookViewModel.Authors = book.Authors.ConvertToAuthorViewModelList();

            return bookViewModel;
        }

        public static List<BookViewModel> ConvertToBookViewModelList(this List<Book> books)
        {
            List<BookViewModel> bookViewModels = new List<BookViewModel>();
            foreach (Book b in books)
            {
                bookViewModels.Add(b.ConvertToBookViewModel());
            }

            return bookViewModels;
        }

        public static UpdateBookRequest ConvertToUpdateBookRequest(this BookViewModel model)
        {
            UpdateBookRequest request = new UpdateBookRequest();
            request.BookId = model.BookId;
            request.Title = model.Title;
            request.ISBN = model.ISBN;
            request.Description = model.Description;
            request.GenreId = Convert.ToInt32(model.Genre.GenreId);
            request.LanguageId = Convert.ToInt32(model.Language.LanguageId);
            request.AuthorIds = new List<int>();
            foreach (int id in model.AuthorIds)
                request.AuthorIds.Add(id);

            return request;
        }

        public static CreateBookRequest ConvertToCreateBookRequest(this BookViewModel model)
        {
            CreateBookRequest request = new CreateBookRequest();
            request.Title = model.Title;
            request.ISBN = model.ISBN;
            request.Description = model.Description;
            request.GenreId = Convert.ToInt32(model.Genre.GenreId);
            request.LanguageId = Convert.ToInt32(model.Language.LanguageId);
            request.AuthorIds = new List<int>();
            foreach (int id in model.AuthorIds)
                request.AuthorIds.Add(id);

            return request;
        }
    }
}