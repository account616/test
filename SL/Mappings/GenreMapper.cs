using DAL.Entities.Genre;
using SL.Messages.Genres;

namespace SL.Mappings
{
    public static class GenreMapper
    {
        public static Genre ConvertToGenre(this CreateGenreRequest createRequest)
        {
            Genre genre = new Genre();
            genre.GenreName = createRequest.Genre;

            return genre;
        }

        public static Genre ConvertToGenre(this UpdateGenreRequest updateRequest)
        {
            Genre genre = new Genre();
            genre.GenreId = updateRequest.GenreId;
            genre.GenreName = updateRequest.Genre;

            return genre;
        }
    }
}
