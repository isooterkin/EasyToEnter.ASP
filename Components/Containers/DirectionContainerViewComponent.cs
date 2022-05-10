using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class DirectionContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<DirectionModel> data) => View(data);
    }
}