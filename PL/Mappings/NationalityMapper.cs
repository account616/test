using DAL.Entities.Nationality;
using PL.Models.ViewModels;
using SL.Messages.Nationalities;
using System.Collections.Generic;

namespace PL.Mappings
{
    public static class NationalityMapper
    {
        public static NationalityViewModel ConvertToNationalityViewModel(this Nationality nationality)
        {
            NationalityViewModel nationalityViewModel = new NationalityViewModel();
            nationalityViewModel.NationalityId = nationality.NationalityId;
            nationalityViewModel.Nationality = nationality.NationalityName;

            return nationalityViewModel;
        }

        public static List<NationalityViewModel> ConvertToNationalityViewModelList(this List<Nationality> nationalities)
        {
            List<NationalityViewModel> nationalityViewModels = new List<NationalityViewModel>();
            foreach(Nationality n in nationalities)
            {
                nationalityViewModels.Add(n.ConvertToNationalityViewModel());
            }

            return nationalityViewModels;
        }

        public static UpdateNationalityRequest ConvertToUpdateNationalityRequest(this NationalityViewModel model)
        {
            UpdateNationalityRequest request = new UpdateNationalityRequest();
            request.NationalityId = model.NationalityId;
            request.Nationality = model.Nationality;

            return request;
        }

        public static CreateNationalityRequest ConvertToCreateNationalityRequest(this NationalityViewModel model)
        {
            CreateNationalityRequest request = new CreateNationalityRequest();
            request.Nationality = model.Nationality;

            return request;
        }
    }
}