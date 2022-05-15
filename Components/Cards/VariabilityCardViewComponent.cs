using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class VariabilityCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(VariabilitySelectionCardViewModel data) => View(data);
    }
}