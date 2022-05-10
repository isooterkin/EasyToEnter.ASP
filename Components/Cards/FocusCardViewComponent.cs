using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class FocusCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(FocusModel data) => View(data);
    }
}