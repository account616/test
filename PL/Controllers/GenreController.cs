using PL.Models.PageViewModels;
using PL.Mappings;
using PL.Models.ViewModels;
using SL.Abstractions;
using SL.Messages.Genres;
using DAL.Entities.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class GenreController : Controller
    {
        private IGenreService _genreService;
        
        public GenreController(IGenreService service)
        {
            _genreService = service;
        }

        public ActionResult Index()
        {
            GenreListPageViewModel model = new GenreListPageViewModel();
            FindAllGenresResponse response = _genreService.FindAllGenres();
            if(response.Success)
            {
                model.GenreViewModels = response.Genres.ConvertToGenreViewModelList();
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
        public ActionResult Index(string genre)
        {
            GenreListPageViewModel model = new GenreListPageViewModel();
            FindAllGenresResponse response = _genreService.FindAllGenres();
            if (response.Success)
            {
                model.GenreViewModels = response.Genres.ConvertToGenreViewModelList();

                if (!String.IsNullOrEmpty(genre))
                    model.GenreViewModels = model.GenreViewModels.Where(x => x.Genre.Contains(genre)).ToList();

                model.Success = true;
            }
            else
            {
                model.Message = response.Message;
                model.Success = false;
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            GenreSinglePageViewModel model = new GenreSinglePageViewModel();
            FindAllGenresResponse response = _genreService.FindAllGenres();
            if (response.Success)
            {
                model.GenreViewModel = response.Genres.Where(x => x.GenreId == id).First().ConvertToGenreViewModel();
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
            GenreSinglePageViewModel model = new GenreSinglePageViewModel();
            model.GenreViewModel = new GenreViewModel();
            model.Success = true;
            return View(model);
        }

        // POST: Language/Create
        [HttpPost]
        public ActionResult Create(GenreSinglePageViewModel model)
        {
            CreateGenreRequest request = model.GenreViewModel.ConvertToCreateGenreRequest();
            CreateGenreResponse response = _genreService.CreateGenre(request);
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
            GenreSinglePageViewModel model = new GenreSinglePageViewModel();
            FindAllGenresResponse response = _genreService.FindAllGenres();
            if(response.Success)
            {
                model.GenreViewModel = response.Genres.Where(x => x.GenreId == id).First().ConvertToGenreViewModel();
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
        public ActionResult Edit(GenreSinglePageViewModel model)
        {
            UpdateGenreRequest request = model.GenreViewModel.ConvertToUpdateGenreRequest();
            UpdateGenreResponse response = _genreService.UpdateGenre(request);
            if(response.Success)
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

        // GET: Language/Delete/5
        public ActionResult Delete(int id)
        {
            DeleteGenreRequest request = new DeleteGenreRequest() { GenreId = id};
            DeleteGenreResponse response = _genreService.DeleteGenre(request);
            if(response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                GenreListPageViewModel model = new GenreListPageViewModel();
                model.Success = false;
                model.Message = response.Message;
                return View("Index", model);
            }
        }
    }
}