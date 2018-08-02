using SL.Messages.Languages;

namespace SL.Abstractions
{
    public interface ILanguageService
    {
        CreateLanguageResponse CreateLnaguage(CreateLanguageRequest request);
        FindAllLanguagesResponse FindAllLanguages();
        UpdateLanguageResponse UpdateLnaguage(UpdateLanguageRequest request);
        DeleteLanguageResponse DeleteLnaguage(DeleteLanguageRequest request);
    }
}
