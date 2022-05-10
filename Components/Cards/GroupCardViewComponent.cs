using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Cards
{
    [ViewComponent]
    public class GroupCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(GroupSelectionCardViewModel data) => View(data);
    }
}