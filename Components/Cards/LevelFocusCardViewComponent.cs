using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class LevelFocusCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(LevelFocusModel data) => View(data);
    }
}