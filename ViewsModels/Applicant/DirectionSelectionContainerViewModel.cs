﻿using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class DirectionSelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<DirectionModel> DirectionList;
        public readonly int LevelId;

        public DirectionSelectionContainerViewModel(List<VariabilityModel> variabilityList, List<DirectionModel> directionList, int level)
        {
            VariabilityList = variabilityList;
            DirectionList = directionList;
            LevelId = level;
        }
    }
}