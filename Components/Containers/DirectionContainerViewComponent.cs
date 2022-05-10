using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class DirectionContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DirectionSelectionContainerViewModel data) => View(data);
    }
}