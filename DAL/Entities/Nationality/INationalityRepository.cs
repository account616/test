using System.Collections.Generic;

namespace DAL.Entities.Nationality
{
    public interface INationalityRepository
    {
        List<Nationality> Read();
        void Update(Nationality entity);
        void Create(Nationality entity);
        void Delete(int id);
    }
}
