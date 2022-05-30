using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class DisciplineContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<DisciplineFocusUniversityModel> data) => View(data);
    }
}