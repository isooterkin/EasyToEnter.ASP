using EasyToEnter.ASP.ViewsModels.Applicant;

namespace EasyToEnter.ASP.ViewsModels.Components.History
{
    public class HistoryContainerViewModel
    {
        public HistoryContainerViewModel(object viewModel)
        {
            switch (viewModel.GetType())
            {
                case var value when value == typeof(VariabilitySelectionContainerViewModel):
                    if (viewModel is VariabilitySelectionContainerViewModel variabilityModel)
                    {
                        LevelHistory = new LevelHistoryViewModel(variabilityModel.LevelName);
                        ScienceHistory = new ScienceHistoryViewModel(variabilityModel.ScienceName, variabilityModel.LevelId);
                        GroupHistory = new GroupHistoryViewModel(variabilityModel.GroupName, variabilityModel.LevelId, variabilityModel.ScienceId);
                        DirectionHistory = new DirectionHistoryViewModel(variabilityModel.DirectionName, variabilityModel.LevelId, variabilityModel.GroupId);
                        FocusHistory = new FocusHistoryViewModel(variabilityModel.FocusName, variabilityModel.LevelId, variabilityModel.DirectionId);
                    }
                    break;
                case var value when value == typeof(FocusSelectionContainerViewModel):
                    if (viewModel is FocusSelectionContainerViewModel focusModel)
                    {
                        LevelHistory = new LevelHistoryViewModel(focusModel.LevelName);
                        ScienceHistory = new ScienceHistoryViewModel(focusModel.ScienceName, focusModel.LevelId);
                        GroupHistory = new GroupHistoryViewModel(focusModel.GroupName, focusModel.LevelId, focusModel.ScienceId);
                        DirectionHistory = new DirectionHistoryViewModel(focusModel.DirectionName, focusModel.LevelId, focusModel.GroupId);
                    }
                    break;
                case var value when value == typeof(DirectionSelectionContainerViewModel):
                    if (viewModel is DirectionSelectionContainerViewModel directionModel)
                    {
                        LevelHistory = new LevelHistoryViewModel(directionModel.LevelName);
                        ScienceHistory = new ScienceHistoryViewModel(directionModel.ScienceName, directionModel.LevelId);
                        GroupHistory = new GroupHistoryViewModel(directionModel.GroupName, directionModel.LevelId, directionModel.ScienceId);
                    }
                    break;
                case var value when value == typeof(GroupSelectionContainerViewModel):
                    if (viewModel is GroupSelectionContainerViewModel groupModel)
                    {
                        LevelHistory = new LevelHistoryViewModel(groupModel.LevelName);
                        ScienceHistory = new ScienceHistoryViewModel(groupModel.ScienceName, groupModel.LevelId);
                    }
                    break;
                case var value when value == typeof(ScienceSelectionContainerViewModel):
                    if (viewModel is ScienceSelectionContainerViewModel scienceModel)
                        LevelHistory = new LevelHistoryViewModel(scienceModel.LevelName);
                    break;
                case var value when value == typeof(LevelSelectionContainerViewModel):
                    break;
            }
        }

        public readonly LevelHistoryViewModel? LevelHistory;
        public readonly ScienceHistoryViewModel? ScienceHistory;
        public readonly GroupHistoryViewModel? GroupHistory;
        public readonly DirectionHistoryViewModel? DirectionHistory;
        public readonly FocusHistoryViewModel? FocusHistory;
    }
}