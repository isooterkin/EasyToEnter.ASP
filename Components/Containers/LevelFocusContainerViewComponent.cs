using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class LevelFocusContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<LevelFocusModel> data) => View(data);
    }
}