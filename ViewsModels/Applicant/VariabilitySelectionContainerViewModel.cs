using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class VariabilitySelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<SelectListItem> FormSelectList;
        public readonly List<SelectListItem> FormatSelectList;
        public readonly List<SelectListItem> PaymentSelectList;
        public readonly List<SelectListItem> EntranceExamsSelectList;
        public readonly int LevelFocusId;

        public VariabilitySelectionContainerViewModel(List<VariabilityModel> variabilityList, List<SelectListItem> formSelectList, List<SelectListItem> formatSelectList, List<SelectListItem> paymentSelectList, List<SelectListItem> entranceExamsSelectList, int levelFocus)
        {
            VariabilityList = variabilityList;
            FormSelectList = formSelectList;
            FormatSelectList = formatSelectList;
            PaymentSelectList = paymentSelectList;
            EntranceExamsSelectList = entranceExamsSelectList;
            LevelFocusId = levelFocus;
        }
    }
}