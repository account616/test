using PL.Mappings;
using PL.Models.PageViewModels;
using PL.Models.ViewModels;
using SL.Abstractions;
using SL.Messages.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private IGenreService _genreService;
        private ILanguageService _languageService;

        public BookController(IBookService bService, IAuthorService aService, IGenreService gService, ILanguageService lService)
        {
            _bookService = bService;
            _authorService = aService;
            _genreService = gService;
            _languageService = lService;
        }

        public ActionResult Index()
        {
            BookListPageViewModel model = new BookListPageViewModel();
            FindAllBooksResponse response = _bookService.FindAllBooks();

            model.AuthorViewModels = _authorService.FindAllAuthors().Authors.ConvertToAuthorViewModelList();
            model.AuthorViewModels.Insert(0, new AuthorViewModel() { AuthorId = null, Name = "Odaberite autora" });

            model.GenreViewModels = _genreService.FindAllGenres().Genres.ConvertToGenreViewModelList();
            model.GenreViewModels.Insert(0, new GenreViewModel() { GenreId = null, Genre = "Odaberite zanr" });

            model.LanguageViewModels = _languageService.FindAllLanguages().Languages.ConvertToLanguageViewModelList();
            model.LanguageViewModels.Insert(0, new LanguageViewModel() { LanguageId = null, Language = "Odaberite jezik" });

            if (response.Success)
            {
                model.BookViewModels = response.Books.ConvertToBookViewModelList();
                model.Success = true;
            }
            else
            {
                model.Message = response.Message;
                model.Success = false;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(BookListPageViewModel model, string titleSearchString, string isbnSearchString)
        {
            BookListPageViewModel newModel = new BookListPageViewModel();
            FindAllBooksResponse response = _bookService.FindAllBooks();

            newModel.AuthorViewModels = _authorService.FindAllAuthors().Authors.ConvertToAuthorViewModelList();
            newModel.AuthorViewModels.Insert(0, new AuthorViewModel() { AuthorId = null, Name = "Odaberite autora" });

            newModel.GenreViewModels = _genreService.FindAllGenres().Genres.ConvertToGenreViewModelList();
            newModel.GenreViewModels.Insert(0, new GenreViewModel() { GenreId = null, Genre = "Odaberite zanr" });

            newModel.LanguageViewModels = _languageService.FindAllLanguages().Languages.ConvertToLanguageViewModelList();
            newModel.LanguageViewModels.Insert(0, new LanguageViewModel() { LanguageId = null, Language = "Odaberite jezik" });

            if (response.Success)
            {
                newModel.BookViewModels = response.Books.ConvertToBookViewModelList();

                if (!String.IsNullOrEmpty(titleSearchString))
                    newModel.BookViewModels = newModel.BookViewModels.Where(x => x.Title.Contains(titleSearchString)).ToList();

                if (!String.IsNullOrEmpty(isbnSearchString))
                    newModel.BookViewModels = newModel.BookViewModels.Where(x => x.ISBN.Contains(isbnSearchString)).ToList();

                if (model.AuthorFilterId != null)
                    newModel.BookViewModels = newModel.BookViewModels.Where(x => x.Authors.Contains(x.Authors.Where(y => y.AuthorId == model.AuthorFilterId).First())).ToList();

                if (model.LanguageFilterId != null)
                    newModel.BookViewModels = newModel.BookViewModels.Where(x => x.Language.LanguageId == model.LanguageFilterId).ToList();

                if (model.GenreFilterId != null)
                    newModel.BookViewModels = newModel.BookViewModels.Where(x => x.Genre.GenreId == model.GenreFilterId).ToList();

                newModel.Success = true;
            }
            else
            {
                newModel.Message = response.Message;
                newModel.Success = false;
            }
            return View(newModel);
        }

        public ActionResult Details(int id)
        {
            BookSinglePageViewModel model = new BookSinglePageViewModel();
            FindAllBooksResponse response = _bookService.FindAllBooks();
            if (response.Success)
            {
                model.BookViewModel = response.Books.Where(x => x.BookId == id).First().ConvertToBookViewModel();
                model.Success = true;
            }
            else
            {
                model.Message = response.Message;
                model.Success = false;
            }
            return View(model);
        }

        public ActionResult Create()
        {
            BookSinglePageViewModel model = new BookSinglePageViewModel();
            model.BookViewModel = new BookViewModel();
            model.AuthorViewModels = _authorService.FindAllAuthors().Authors.ConvertToAuthorViewModelList();
            model.GenreViewModels = _genreService.FindAllGenres().Genres.ConvertToGenreViewModelList();
            model.GenreViewModels.Insert(0, new GenreViewModel() { GenreId = null, Genre = "Odaberite zanr" });
            model.LanguageViewModels = _languageService.FindAllLanguages().Languages.ConvertToLanguageViewModelList();
            model.LanguageViewModels.Insert(0, new LanguageViewModel() { LanguageId = null, Language = "Odaberite jezik" });
            model.Success = true;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookSinglePageViewModel model)
        {
            CreateBookRequest request = model.BookViewModel.ConvertToCreateBookRequest();
            CreateBookResponse response = _bookService.CreateBook(request);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                model.Success = false;
                model.Message = response.Message;
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            BookSinglePageViewModel model = new BookSinglePageViewModel();
            FindAllBooksResponse response = _bookService.FindAllBooks();
            model.GenreViewModels = _genreService.FindAllGenres().Genres.ConvertToGenreViewModelList();
            model.LanguageViewModels = _languageService.FindAllLanguages().Languages.ConvertToLanguageViewModelList();
            model.AuthorViewModels = _authorService.FindAllAuthors().Authors.ConvertToAuthorViewModelList();

            if (response.Success)
            {
                model.BookViewModel = response.Books.Where(x => x.BookId == id).First().ConvertToBookViewModel();
                model.Success = true;
            }
            else
            {
                model.Success = false;
                model.Message = response.Message;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookSinglePageViewModel model)
        {
            UpdateBookRequest request = model.BookViewModel.ConvertToUpdateBookRequest();
            UpdateBookResponse response = _bookService.UpdateBook(request);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                model.Success = false;
                model.Message = response.Message;
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            DeleteBookRequest request = new DeleteBookRequest() { BookId = id };
            DeleteBookResponse response = _bookService.DeleteBook(request);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                BookListPageViewModel model = new BookListPageViewModel();
                model.Success = false;
                model.Message = response.Message;
                return View("Index", model);
            }
        }
    }
}