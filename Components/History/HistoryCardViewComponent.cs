using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.History
{
    [ViewComponent]
    public class HistoryCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(HistoryVariabilityModel data) => View(data);
    }
}