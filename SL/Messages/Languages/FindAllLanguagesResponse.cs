using DAL.Entities.Language;
using System.Collections.Generic;

namespace SL.Messages.Languages
{
    public class FindAllLanguagesResponse : ResponseBase
    {
        public List<Language> Languages { get; set; }
    }
}
