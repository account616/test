using DAL.Entities.Genre;
using PL.Models.PageViewModels;
using PL.Models.ViewModels;
using SL.Messages.Genres;
using System;
using System.Collections.Generic;

namespace PL.Mappings
{
    public static class GenreMapper
    {
        public static GenreViewModel ConvertToGenreViewModel(this Genre genre)
        {
            GenreViewModel genreViewModel = new GenreViewModel();
            genreViewModel.GenreId = genre.GenreId;
            genreViewModel.Genre = genre.GenreName;

            return genreViewModel;
        }

        public static List<GenreViewModel> ConvertToGenreViewModelList(this List<Genre> genres)
        {
            List<GenreViewModel> genreViewModels = new List<GenreViewModel>();
            foreach (Genre g in genres)
            {
                genreViewModels.Add(g.ConvertToGenreViewModel());
            }

            return genreViewModels;
        }

        public static UpdateGenreRequest ConvertToUpdateGenreRequest(this GenreViewModel model)
        {
            UpdateGenreRequest request = new UpdateGenreRequest();
            request.GenreId = Convert.ToInt32(model.GenreId);
            request.Genre = model.Genre;

            return request;
        }

        public static CreateGenreRequest ConvertToCreateGenreRequest(this GenreViewModel model)
        {
            CreateGenreRequest request = new CreateGenreRequest();
            request.Genre = model.Genre;

            return request;
        }
    }
}