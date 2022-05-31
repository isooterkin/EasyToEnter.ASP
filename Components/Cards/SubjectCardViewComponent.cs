using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class SubjectCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(SubjectFocusUniversityModel data) => View(data);
    }
}