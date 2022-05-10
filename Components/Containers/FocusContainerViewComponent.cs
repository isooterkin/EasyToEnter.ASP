using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class FocusContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(FocusSelectionContainerViewModel data) => View(data);
    }
}