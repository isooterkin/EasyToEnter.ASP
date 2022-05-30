using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;

namespace EasyToEnter.ASP.ViewsModels.Components.Path
{
    public class PathContainerViewModel
    {
        public readonly bool CorrectLink = false;
        public readonly LevelPathViewModel? LevelHistory;
        public readonly SciencePathViewModel? ScienceHistory;
        public readonly GroupPathViewModel? GroupHistory;
        public readonly DirectionPathViewModel? DirectionHistory;
        public readonly FocusPathViewModel? FocusHistory;
        public readonly VariabilityPathViewModel? VariabilityHistory;

        public PathContainerViewModel(object? viewModel)
        {
            if (viewModel == null) return;

            switch (viewModel.GetType())
            {
                case var value when value == typeof(VariabilityModel):
                    if (viewModel is VariabilityModel variability)
                    {
                        LevelHistory = new LevelPathViewModel(variability.FocusUniversityModel!.LevelFocusModel!.LevelModel!.Name);
                        ScienceHistory = new SciencePathViewModel(variability.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceModel!.Name, variability.FocusUniversityModel!.LevelFocusModel!.LevelId);
                        GroupHistory = new GroupPathViewModel(variability.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.Name, variability.FocusUniversityModel!.LevelFocusModel!.LevelId, variability.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceId);
                        DirectionHistory = new DirectionPathViewModel(variability.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.Name, variability.FocusUniversityModel!.LevelFocusModel!.LevelId, variability.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupId);
                        FocusHistory = new FocusPathViewModel(variability.FocusUniversityModel!.LevelFocusModel!.FocusModel!.Name, variability.FocusUniversityModel!.LevelFocusModel!.LevelId, variability.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionId);
                        VariabilityHistory = new VariabilityPathViewModel(variability.FocusUniversityModel!.UniversityModel!.Name, variability.FocusUniversityModel.LevelFocusId);
                        CorrectLink = true;
                    }
                    break;
                case var value when value == typeof(VariabilitySelectionContainerViewModel):
                    if (viewModel is VariabilitySelectionContainerViewModel variabilityModel)
                        if (variabilityModel.VariabilityList.Any())
                        {
                            LevelHistory = new LevelPathViewModel(variabilityModel.LevelName);
                            ScienceHistory = new SciencePathViewModel(variabilityModel.ScienceName, variabilityModel.LevelId);
                            GroupHistory = new GroupPathViewModel(variabilityModel.GroupName, variabilityModel.LevelId, variabilityModel.ScienceId);
                            DirectionHistory = new DirectionPathViewModel(variabilityModel.DirectionName, variabilityModel.LevelId, variabilityModel.GroupId);
                            FocusHistory = new FocusPathViewModel(variabilityModel.FocusName, variabilityModel.LevelId, variabilityModel.DirectionId);
                            CorrectLink = true;
                        }
                    break;
                case var value when value == typeof(FocusSelectionContainerViewModel):
                    if (viewModel is FocusSelectionContainerViewModel focusModel)
                        if (focusModel.LevelFocusList.Any())
                        {
                            LevelHistory = new LevelPathViewModel(focusModel.LevelName);
                            ScienceHistory = new SciencePathViewModel(focusModel.ScienceName, focusModel.LevelId);
                            GroupHistory = new GroupPathViewModel(focusModel.GroupName, focusModel.LevelId, focusModel.ScienceId);
                            DirectionHistory = new DirectionPathViewModel(focusModel.DirectionName, focusModel.LevelId, focusModel.GroupId);
                            CorrectLink = true;
                        }
                    break;
                case var value when value == typeof(DirectionSelectionContainerViewModel):
                    if (viewModel is DirectionSelectionContainerViewModel directionModel)
                        if (directionModel.DirectionList.Any())
                        {
                            LevelHistory = new LevelPathViewModel(directionModel.LevelName);
                            ScienceHistory = new SciencePathViewModel(directionModel.ScienceName, directionModel.LevelId);
                            GroupHistory = new GroupPathViewModel(directionModel.GroupName, directionModel.LevelId, directionModel.ScienceId);
                            CorrectLink = true;
                        }
                    break;
                case var value when value == typeof(GroupSelectionContainerViewModel):
                    if (viewModel is GroupSelectionContainerViewModel groupModel)
                        if (groupModel.GroupList.Any())
                        {
                            LevelHistory = new LevelPathViewModel(groupModel.LevelName);
                            ScienceHistory = new SciencePathViewModel(groupModel.ScienceName, groupModel.LevelId);
                            CorrectLink = true;
                        }
                    break;
                case var value when value == typeof(ScienceSelectionContainerViewModel):
                    if (viewModel is ScienceSelectionContainerViewModel scienceModel)
                        if (scienceModel.ScienceList.Any())
                        {
                            LevelHistory = new LevelPathViewModel(scienceModel.LevelName);
                            CorrectLink = true;
                        }
                    break;
                case var value when value == typeof(LevelSelectionContainerViewModel):
                    if (viewModel is LevelSelectionContainerViewModel levelModel)
                        if (levelModel.LevelList.Any())
                            CorrectLink = true;
                    break;
                default:
                    break;
            }
        }
    }
}