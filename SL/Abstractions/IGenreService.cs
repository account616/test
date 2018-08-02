using SL.Messages.Genres;

namespace SL.Abstractions
{
    public interface IGenreService
    {
        CreateGenreResponse CreateGenre(CreateGenreRequest request);
        FindAllGenresResponse FindAllGenres();
        UpdateGenreResponse UpdateGenre(UpdateGenreRequest request);
        DeleteGenreResponse DeleteGenre(DeleteGenreRequest request);

    }
}
