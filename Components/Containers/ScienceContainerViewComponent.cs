using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class ScienceContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ScienceSelectionContainerViewModel data) => View(data);
    }
}