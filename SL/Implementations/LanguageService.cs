using System;
using DAL.Entities.Language;
using SL.Abstractions;
using SL.Messages.Languages;
using SL.Mappings;

namespace SL.Implementations
{
    public class LanguageService : ILanguageService
    {
        private ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository repository)
        {
            _languageRepository = repository;
        }

        public CreateLanguageResponse CreateLnaguage(CreateLanguageRequest request)
        {
            CreateLanguageResponse response = new CreateLanguageResponse();
            try
            {
                Language language = request.ConvertToLanguage();
                _languageRepository.Create(language);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public DeleteLanguageResponse DeleteLnaguage(DeleteLanguageRequest request)
        {
            DeleteLanguageResponse response = new DeleteLanguageResponse();
            try
            {
                _languageRepository.Delete(request.LanguageId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public FindAllLanguagesResponse FindAllLanguages()
        {
            FindAllLanguagesResponse response = new FindAllLanguagesResponse();
            try
            {
                response.Languages = _languageRepository.Read();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public UpdateLanguageResponse UpdateLnaguage(UpdateLanguageRequest request)
        {
            UpdateLanguageResponse response = new UpdateLanguageResponse();
            try
            {
                Language language = request.ConvertToLanguage();
                _languageRepository.Update(language);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
