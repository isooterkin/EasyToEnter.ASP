using EasyToEnter.ASP.ViewsModels.Components.History;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.History
{
    [ViewComponent]
    public class HistoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(HistoryContainerViewModel data) => View(data);
    }
}