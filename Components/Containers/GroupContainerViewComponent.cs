using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Containers
{
    [ViewComponent]
    public class GroupContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<GroupModel> data) => View(data);
    }
}