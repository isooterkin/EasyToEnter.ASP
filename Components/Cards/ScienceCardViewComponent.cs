using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class ScienceCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ScienceSelectionCardViewModel data) => View(data);
    }
}