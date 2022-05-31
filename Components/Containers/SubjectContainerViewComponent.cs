using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class SubjectContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<SubjectFocusUniversityModel> data) => View(data);
    }
}