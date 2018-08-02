using System.Collections.Generic;

namespace DAL.Entities.Author
{
    public interface IAuthorRepository
    {
        List<Author> Read();
        void Update(Author entity);
        void Create(Author entity);
        void Delete(int id);
    }
}
