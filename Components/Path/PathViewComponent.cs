using EasyToEnter.ASP.ViewsModels.Components.Path;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Path
{
    [ViewComponent]
    public class PathViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PathContainerViewModel data) => View(data);
    }
}