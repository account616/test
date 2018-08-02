using DAL.Entities.Language;
using PL.Models.ViewModels;
using SL.Messages.Languages;
using System;
using System.Collections.Generic;

namespace PL.Mappings
{
    public static class LanguageMapper
    {
        public static LanguageViewModel ConvertToLanguageViewModel(this Language language)
        {
            LanguageViewModel languageViewModel = new LanguageViewModel();
            languageViewModel.LanguageId = language.LanguageId;
            languageViewModel.Language = language.LanguageName;

            return languageViewModel;
        }

        public static List<LanguageViewModel> ConvertToLanguageViewModelList(this List<Language> languages)
        {
            List<LanguageViewModel> languageViewModels = new List<LanguageViewModel>();
            foreach (Language l in languages)
            {
                languageViewModels.Add(l.ConvertToLanguageViewModel());
            }

            return languageViewModels;
        }
        
        public static UpdateLanguageRequest ConvertToUpdateLanguageRequest(this LanguageViewModel model)
        {
            UpdateLanguageRequest request = new UpdateLanguageRequest();
            request.LanguageId = Convert.ToInt32(model.LanguageId);
            request.Language = model.Language;

            return request;
        }

        public static CreateLanguageRequest ConvertToCreateLanguageRequest(this LanguageViewModel model)
        {
            CreateLanguageRequest request = new CreateLanguageRequest();
            request.Language = model.Language;

            return request;
        }
    }
}