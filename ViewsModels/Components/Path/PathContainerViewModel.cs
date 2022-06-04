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
                        LevelFocusModel levelFocusModel = variability.FocusUniversityModel!.LevelFocusModel!;

                        LevelHistory = new LevelPathViewModel(levelFocusModel.LevelModel!.Name);
                        ScienceHistory = new SciencePathViewModel(levelFocusModel.FocusModel!.DirectionModel!.GroupModel!.ScienceModel!.Name, levelFocusModel.LevelId);
                        GroupHistory = new GroupPathViewModel(levelFocusModel.GroupFullName, variability.FocusUniversityModel!.LevelFocusModel!.LevelId, levelFocusModel.FocusModel!.DirectionModel!.GroupModel!.ScienceId);
                        DirectionHistory = new DirectionPathViewModel(levelFocusModel.DirectionFullName, variability.FocusUniversityModel!.LevelFocusModel!.LevelId, levelFocusModel.FocusModel!.DirectionModel!.GroupId);
                        FocusHistory = new FocusPathViewModel(levelFocusModel.FocusFullName, variability.FocusUniversityModel!.LevelFocusModel!.LevelId, levelFocusModel.FocusModel!.DirectionId);
                        VariabilityHistory = new VariabilityPathViewModel(variability.FocusUniversityModel!.UniversityModel!.Name, variability.FocusUniversityModel.LevelFocusId, variability.FocusUniversityModel.UniversityModel.Id);
                        CorrectLink = true;
                    }
                    break;
                case var value when value == typeof(VariabilitySelectionContainerViewModel):
                    if (viewModel is VariabilitySelectionContainerViewModel variabilityModel)
                        if (variabilityModel.VariabilityViewModelList.Any())
                        {
                            LevelFocusModel levelFocusModel = variabilityModel.VariabilityViewModelList[0]!.FocusUniversityModel!.LevelFocusModel!;

                            LevelHistory = new LevelPathViewModel(variabilityModel.LevelName);
                            ScienceHistory = new SciencePathViewModel(variabilityModel.ScienceName, variabilityModel.LevelId);
                            GroupHistory = new GroupPathViewModel(levelFocusModel.GroupFullName, variabilityModel.LevelId, variabilityModel.ScienceId);
                            DirectionHistory = new DirectionPathViewModel(levelFocusModel.DirectionFullName, variabilityModel.LevelId, variabilityModel.GroupId);
                            FocusHistory = new FocusPathViewModel(levelFocusModel.FocusFullName, variabilityModel.LevelId, variabilityModel.DirectionId);
                            CorrectLink = true;
                        }
                    break;
                case var value when value == typeof(FocusSelectionContainerViewModel):
                    if (viewModel is FocusSelectionContainerViewModel focusModel)
                        if (focusModel.LevelFocusList.Any())
                        {
                            LevelFocusModel levelFocusModel = focusModel.LevelFocusList[0];

                            LevelHistory = new LevelPathViewModel(focusModel.LevelName);
                            ScienceHistory = new SciencePathViewModel(focusModel.ScienceName, focusModel.LevelId);
                            GroupHistory = new GroupPathViewModel(levelFocusModel.GroupFullName, focusModel.LevelId, focusModel.ScienceId);
                            DirectionHistory = new DirectionPathViewModel(levelFocusModel.DirectionFullName, focusModel.LevelId, focusModel.GroupId);
                            CorrectLink = true;
                        }
                    break;
                case var value when value == typeof(DirectionSelectionContainerViewModel):
                    if (viewModel is DirectionSelectionContainerViewModel directionModel)
                        if (directionModel.DirectionList.Any())
                        {
                            LevelFocusModel levelFocusModel = directionModel.VariabilityList[0]!.FocusUniversityModel!.LevelFocusModel!;

                            LevelHistory = new LevelPathViewModel(directionModel.LevelName);
                            ScienceHistory = new SciencePathViewModel(directionModel.ScienceName, directionModel.LevelId);
                            GroupHistory = new GroupPathViewModel(levelFocusModel.GroupFullName, directionModel.LevelId, directionModel.ScienceId);
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