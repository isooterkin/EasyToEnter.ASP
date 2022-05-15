using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class VariabilityContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(VariabilitySelectionContainerViewModel data) => View(data);
    }
}