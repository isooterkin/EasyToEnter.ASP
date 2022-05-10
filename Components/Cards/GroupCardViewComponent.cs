using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class GroupCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(GroupModel data) => View(data);
    }
}