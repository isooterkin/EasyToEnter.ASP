using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Maps
{
    [ViewComponent]
    public class MapUniversityListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<UniversityModel> data) => View(data);
    }
}