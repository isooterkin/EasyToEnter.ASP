using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.History
{
    [ViewComponent]
    public class HistoryContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<HistoryVariabilityModel> data) => View(data);
    }
}