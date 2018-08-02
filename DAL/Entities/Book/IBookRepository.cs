using System.Collections.Generic;

namespace DAL.Entities.Book
{
    public interface IBookRepository
    {
        List<Book> Read();
        void Update(Book entity);
        void Create(Book entity);
        void Delete(int id);
    }
}
