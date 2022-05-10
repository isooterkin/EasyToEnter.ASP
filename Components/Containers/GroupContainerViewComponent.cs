using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class GroupContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(GroupSelectionContainerViewModel data) => View(data);
    }
}