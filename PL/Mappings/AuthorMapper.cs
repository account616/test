using DAL.Entities.Author;
using PL.Models.ViewModels;
using SL.Messages.Authors;
using System;
using System.Collections.Generic;

namespace PL.Mappings
{
    public static class AuthorMapper
    {
        public static AuthorViewModel ConvertToAuthorViewModel(this Author author)
        {
            AuthorViewModel authorViewModel = new AuthorViewModel();
            authorViewModel.AuthorId = author.AuthorId;
            authorViewModel.Name = author.Name;
            authorViewModel.Nationality = author.Nationality.ConvertToNationalityViewModel();
            //    new NationalityViewModel() { NationalityId = author.Nationality.NationalityId,
            //                                 Nationality = author.Nationality.NationalityName };

            return authorViewModel;
        }

        public static List<AuthorViewModel> ConvertToAuthorViewModelList(this List<Author> authors)
        {
            List<AuthorViewModel> authorViewModels = new List<AuthorViewModel>();
            foreach (Author a in authors)
            {
                authorViewModels.Add(a.ConvertToAuthorViewModel());
            }

            return authorViewModels;
        }

        public static UpdateAuthorRequest ConvertToUpdateAuthorRequest(this AuthorViewModel model)
        {
            UpdateAuthorRequest request = new UpdateAuthorRequest();
            request.AuthorId = Convert.ToInt32(model.AuthorId);
            request.Name = model.Name;
            request.NationalityId = model.Nationality.NationalityId;

            return request;
        }

        public static CreateAuthorRequest ConvertToCreateNationalityRequest(this AuthorViewModel model)
        {
            CreateAuthorRequest request = new CreateAuthorRequest();
            request.Name = model.Name;
            request.NationalityId = model.Nationality.NationalityId;

            return request;
        }
    }
}