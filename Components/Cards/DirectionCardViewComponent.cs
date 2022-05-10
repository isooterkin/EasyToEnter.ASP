using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class DirectionCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DirectionSelectionCardViewModel data) => View(data);
    }
}