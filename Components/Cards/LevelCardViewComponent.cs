using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class LevelCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(LevelModel data) => View(data);
    }
}