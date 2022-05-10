using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class LevelContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<LevelModel> data) => View(data);
    }
}