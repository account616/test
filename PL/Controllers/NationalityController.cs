using PL.Models.PageViewModels;
using PL.Models.ViewModels;
using PL.Mappings;
using SL.Abstractions;
using SL.Messages.Nationalities;
using System.Linq;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class NationalityController : Controller
    {
        private INationalityService _nationalityService;

        public NationalityController(INationalityService service)
        {
            _nationalityService = service;
        }

        public ActionResult Index()
        {
            NationalityListPageViewModel model = new NationalityListPageViewModel();
            FindAllNationalitiesResponse response = _nationalityService.FindAllNationalities();
            if (response.Success)
            {
                model.NationalityViewModels = response.Nationalities.ConvertToNationalityViewModelList();
                model.Success = true;
            }
            else
            {
                model.Message = response.Message;
                model.Success = false;
            }
            return View(model);
        }

        public ActionResult Create()
        {
            NationalitySinglePageViewModel model = new NationalitySinglePageViewModel();
            model.NationalityViewModel = new NationalityViewModel();
            model.Success = true;
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Create(NationalitySinglePageViewModel model)
        {
            CreateNationalityRequest request = model.NationalityViewModel.ConvertToCreateNationalityRequest();
            CreateNationalityResponse response = _nationalityService.CreateNationality(request);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                model.Success = false;
                model.Message = response.Message;
                return View(model);
            }
        }
        
        public ActionResult Edit(int id)
        {
            NationalitySinglePageViewModel model = new NationalitySinglePageViewModel();
            FindAllNationalitiesResponse response = _nationalityService.FindAllNationalities();
            if (response.Success)
            {
                model.NationalityViewModel = response.Nationalities.Where(x => x.NationalityId == id).First().ConvertToNationalityViewModel();
                model.Success = true;
            }
            else
            {
                model.Success = false;
                model.Message = response.Message;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(NationalitySinglePageViewModel model)
        {
            UpdateNationalityRequest request = model.NationalityViewModel.ConvertToUpdateNationalityRequest();
            UpdateNationalityResponse response = _nationalityService.UpdateNatonality(request);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                model.Success = false;
                model.Message = response.Message;
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            DeleteNationalityRequest request = new DeleteNationalityRequest() { NationalityId = id };
            DeleteNationalityResponse response = _nationalityService.DeleteNationality(request);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                NationalityListPageViewModel model = new NationalityListPageViewModel();
                model.Success = false;
                model.Message = response.Message;
                return View("Index", model);
            }
        }
    }
}