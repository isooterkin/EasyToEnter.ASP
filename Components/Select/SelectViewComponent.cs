using EasyToEnter.ASP.ViewsModels.Components;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Select
{
    [ViewComponent]
    public class SelectViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(SelectViewModel data) => View(data);
    }
}