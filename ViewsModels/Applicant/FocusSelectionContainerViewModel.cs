using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Components;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class FocusSelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<LevelFocusModel> LevelFocusList;
        public readonly List<SelectListItemSubtext> AreaSelectListItem;
        public readonly int Level;
        public readonly int Direction;

        public FocusSelectionContainerViewModel(List<VariabilityModel> variabilityList, List<LevelFocusModel> levelFocusList, List<SelectListItemSubtext> areaSelectListItem, int level, int direction)
        {
            VariabilityList = variabilityList;
            LevelFocusList = levelFocusList;
            AreaSelectListItem = areaSelectListItem;
            Level = level;
            Direction = direction;
        }
    }
}