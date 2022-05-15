using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class LevelCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(LevelSelectionCardViewModel data) => View(data);
    }
}