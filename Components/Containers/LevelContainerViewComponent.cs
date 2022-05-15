using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class LevelContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(LevelSelectionContainerViewModel data) => View(data);
    }
}