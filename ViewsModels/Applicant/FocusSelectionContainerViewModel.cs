using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class FocusSelectionContainerViewModel
    {
        public readonly List<LevelFocusModel> LevelFocusList;
        public readonly IEnumerable<FocusUniversityModel> FocusUniversityCollection;
        public readonly List<SelectListItem> AreaFocusList;

        public FocusSelectionContainerViewModel(List<LevelFocusModel> levelFocusList, IEnumerable<FocusUniversityModel> focusUniversityCollection, List<SelectListItem> areaFocusList)
        {
            LevelFocusList = levelFocusList;
            FocusUniversityCollection = focusUniversityCollection;
            AreaFocusList = areaFocusList;
        }
    }
}