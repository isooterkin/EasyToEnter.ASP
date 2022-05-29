using EasyToEnter.ASP.ViewsModels.Components.Maps;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Maps
{
    [ViewComponent]
    public class UniversityBalloonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(UniversityViewModel data) => View(data);
    }
}