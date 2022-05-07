using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyToEnter.ASP.ViewsModels
{
    public class AllInfoViewModel
    {
        public readonly List<SelectListItem> Levels;
        public readonly List<SelectListItem> Sciences;
        public readonly List<SelectListItem> Groups;
        public readonly List<SelectListItem> Directions;
        public readonly List<LevelFocusModel> Focuss;

        public AllInfoViewModel(List<SelectListItem> levels, List<SelectListItem> sciences, List<SelectListItem> groups, List<SelectListItem> directions, List<LevelFocusModel> focuss)
        {
            Levels = levels;
            Sciences = sciences;
            Groups = groups;
            Directions = directions;
            Focuss = focuss;
        }
    }
}