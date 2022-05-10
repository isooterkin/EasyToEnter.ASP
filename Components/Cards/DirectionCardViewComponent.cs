using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class DirectionCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DirectionModel data) => View(data);
    }
}