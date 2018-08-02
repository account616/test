using PL.Models.PageViewModels;
using PL.Models.ViewModels;
using PL.Mappings;
using SL.Abstractions;
using SL.Messages.Authors;
using System.Linq;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorService _authorService;
        private INationalityService _nationalityService;

        public AuthorController(IAuthorService aService, INationalityService nService)
        {
            _authorService = aService;
            _nationalityService = nService;
        }

        public ActionResult Index()
        {
            AuthorListPageViewModel model = new AuthorListPageViewModel();
            FindAllAuthorsResponse response = _authorService.FindAllAuthors();
            if (response.Success)
            {
                model.AuthorViewModels = response.Authors.ConvertToAuthorViewModelList();
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
            AuthorSinglePageViewModel model = new AuthorSinglePageViewModel();
            model.AuthorViewModel = new AuthorViewModel();
            model.AuthorViewModel.Nationality = new NationalityViewModel();
            model.NationalityViewModels = _nationalityService.FindAllNationalities().Nationalities.ConvertToNationalityViewModelList();
            model.Success = true;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AuthorSinglePageViewModel model)
        {
            CreateAuthorRequest request = model.AuthorViewModel.ConvertToCreateNationalityRequest();
            CreateAuthorResponse response = _authorService.CreateAuthor(request);
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
            AuthorSinglePageViewModel model = new AuthorSinglePageViewModel();
            FindAllAuthorsResponse response = _authorService.FindAllAuthors();
            if (response.Success)
            {
                model.AuthorViewModel = response.Authors.Where(x => x.AuthorId == id).First().ConvertToAuthorViewModel();
                model.NationalityViewModels = _nationalityService.FindAllNationalities().Nationalities.ConvertToNationalityViewModelList();
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
        public ActionResult Edit(AuthorSinglePageViewModel model)
        {
            UpdateAuthorRequest request = model.AuthorViewModel.ConvertToUpdateAuthorRequest();
            UpdateAuthorResponse response = _authorService.UpdateAuthor(request);
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
            DeleteAuthorRequest request = new DeleteAuthorRequest() { AuthorId = id };
            DeleteAuthorResponse response = _authorService.DeleteAuthor(request);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                AuthorListPageViewModel model = new AuthorListPageViewModel();
                model.Success = false;
                model.Message = response.Message;
                return View("Index", model);
            }
        }
    }
}