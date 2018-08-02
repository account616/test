using System.Collections.Generic;

namespace DAL.Entities.Language
{
    public interface ILanguageRepository
    {
        List<Language> Read();
        void Update(Language entity);
        void Create(Language entity);
        void Delete(int id);
    }
}
