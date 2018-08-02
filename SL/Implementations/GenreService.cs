using System;
using DAL.Entities.Genre;
using SL.Abstractions;
using SL.Messages.Genres;
using SL.Mappings;

namespace SL.Implementations
{
    public class GenreService : IGenreService
    {
        private IGenreRepository _genreRepository;

        public GenreService(IGenreRepository repository)
        {
            _genreRepository = repository;
        }

        public CreateGenreResponse CreateGenre(CreateGenreRequest request)
        {
            CreateGenreResponse response = new CreateGenreResponse();
            try
            {
                Genre genre = request.ConvertToGenre();
                _genreRepository.Create(genre);
                response.Success = true;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public DeleteGenreResponse DeleteGenre(DeleteGenreRequest request)
        {
            DeleteGenreResponse response = new DeleteGenreResponse();
            try
            {
                _genreRepository.Delete(request.GenreId);
                response.Success = true;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public FindAllGenresResponse FindAllGenres()
        {
            FindAllGenresResponse response = new FindAllGenresResponse();
            try
            {
                response.Genres = _genreRepository.Read();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public UpdateGenreResponse UpdateGenre(UpdateGenreRequest request)
        {
            UpdateGenreResponse response = new UpdateGenreResponse();
            try
            {
                Genre genre = request.ConvertToGenre();
                _genreRepository.Update(genre);
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
