using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class VariabilitySelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<SelectListItem> FormSelectListItem;
        public readonly List<SelectListItem> FormatSelectListItem;
        public readonly List<SelectListItem> PaymentSelectListItem;
        public readonly List<SelectListItem> EntranceExamsSelectListItem;
        public readonly int LevelFocusId;

        public VariabilitySelectionContainerViewModel(List<VariabilityModel> variabilityList, List<SelectListItem> formSelectListItem, List<SelectListItem> formatSelectListItem, List<SelectListItem> paymentSelectListItem, List<SelectListItem> entranceExamsSelectListItem, int levelFocus)
        {
            VariabilityList = variabilityList;
            FormSelectListItem = formSelectListItem;
            FormatSelectListItem = formatSelectListItem;
            PaymentSelectListItem = paymentSelectListItem;
            EntranceExamsSelectListItem = entranceExamsSelectListItem;
            LevelFocusId = levelFocus;
        }
    }
}