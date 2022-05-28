using EasyToEnter.ASP.ViewsModels.Components.Maps;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Maps
{
    [ViewComponent]
    public class MapCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(MapCardViewModel data) => View(data);
    }
}