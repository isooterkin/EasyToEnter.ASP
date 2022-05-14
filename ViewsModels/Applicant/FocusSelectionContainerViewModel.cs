using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class FocusSelectionContainerViewModel
    {
        public readonly List<LevelFocusModel> LevelFocusList;
        public readonly IEnumerable<FocusUniversityModel> FocusUniversityCollection;
        public readonly List<SelectListItem> AreaFocusSelectList;
        public readonly int Level;
        public readonly int Direction;

        public FocusSelectionContainerViewModel(List<LevelFocusModel> levelFocusList, IEnumerable<FocusUniversityModel> focusUniversityCollection, List<SelectListItem> areaFocusSelectList, int level, int direction)
        {
            LevelFocusList = levelFocusList;
            FocusUniversityCollection = focusUniversityCollection;
            AreaFocusSelectList = areaFocusSelectList;
            Level = level;
            Direction = direction;
        }
    }
}