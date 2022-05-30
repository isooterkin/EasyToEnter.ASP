using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class DisciplineCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DisciplineFocusUniversityModel data) => View(data);
    }
}