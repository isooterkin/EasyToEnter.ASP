using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class FocusContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<FocusModel> data) => View(data);
    }
}