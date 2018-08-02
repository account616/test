using System.Collections.Generic;

namespace DAL.Entities.Genre
{
    public interface IGenreRepository
    {
        List<Genre> Read();
        void Update(Genre entity);
        void Create(Genre entity);
        void Delete(int id);
    }
}
