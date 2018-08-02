using PL.Models.PageViewModels;
using PL.Mappings;
using SL.Abstractions;
using SL.Messages.Languages;
using System.Linq;
using System.Web.Mvc;
using PL.Models.ViewModels;

namespace PL.Controllers
{
    public class LanguageController : Controller
    {
        private ILanguageService _languageService;

        public LanguageController(ILanguageService service)
        {
            _languageService = service;
        }

        public ActionResult Index()
        {
            LanguageListPageViewModel model = new LanguageListPageViewModel();
            FindAllLanguagesResponse response = _languageService.FindAllLanguages();
            if (response.Success)
            {
                model.LanguageViewModels = response.Languages.ConvertToLanguageViewModelList();
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
            LanguageSinglePageViewModel model = new LanguageSinglePageViewModel();
            model.LanguageViewModel = new LanguageViewModel();
            model.Success = true;
            return View(model);
        }

        // POST: Language/Create
        [HttpPost]
        public ActionResult Create(LanguageSinglePageViewModel model)
        {
            CreateLanguageRequest request = model.LanguageViewModel.ConvertToCreateLanguageRequest();
            CreateLanguageResponse response = _languageService.CreateLnaguage(request);
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
            LanguageSinglePageViewModel model = new LanguageSinglePageViewModel();
            FindAllLanguagesResponse response = _languageService.FindAllLanguages();
            if (response.Success)
            {
                model.LanguageViewModel = response.Languages.Where(x => x.LanguageId == id).First().ConvertToLanguageViewModel();
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
        public ActionResult Edit(LanguageSinglePageViewModel model)
        {
            UpdateLanguageRequest request = model.LanguageViewModel.ConvertToUpdateLanguageRequest();
            UpdateLanguageResponse response = _languageService.UpdateLnaguage(request);
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
            DeleteLanguageRequest request = new DeleteLanguageRequest() { LanguageId = id };
            DeleteLanguageResponse response = _languageService.DeleteLnaguage(request);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                LanguageListPageViewModel model = new LanguageListPageViewModel();
                model.Success = false;
                model.Message = response.Message;
                return View("Index", model);
            }
        }
    }
}
