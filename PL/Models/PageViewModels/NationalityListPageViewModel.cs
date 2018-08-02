using PL.Models.ViewModels;
using System.Collections.Generic;

namespace PL.Models.PageViewModels
{
    public class NationalityListPageViewModel : PageViewModelBase
    {
        public List<NationalityViewModel> NationalityViewModels { get; set; }
    }
}