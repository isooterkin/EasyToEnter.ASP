using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Maps
{
    [ViewComponent]
    public class DormitoryHintViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DormitoryModel data) => View(data);
    }
}