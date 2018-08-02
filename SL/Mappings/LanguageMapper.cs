using DAL.Entities.Language;
using SL.Messages.Languages;

namespace SL.Mappings
{
    public static class LanguageMapper
    {
        public static Language ConvertToLanguage(this CreateLanguageRequest createRequest)
        {
            Language language = new Language();
            language.LanguageName = createRequest.Language;

            return language;
        }

        public static Language ConvertToLanguage(this UpdateLanguageRequest updateRequest)
        {
            Language language = new Language();
            language.LanguageId = updateRequest.LanguageId;
            language.LanguageName = updateRequest.Language;

            return language;
        }
    }
}
