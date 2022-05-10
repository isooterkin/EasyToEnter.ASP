using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class FocusCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(FocusSelectionCardViewModel data) => View(data);
    }
}