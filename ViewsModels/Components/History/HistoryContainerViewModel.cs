namespace EasyToEnter.ASP.ViewsModels.Components.History
{
    public class HistoryContainerViewModel
    {
        public HistoryContainerViewModel(LevelHistoryViewModel? levelHistory = null, ScienceHistoryViewModel? scienceHistory = null,
            GroupHistoryViewModel? groupHistory = null, DirectionHistoryViewModel? directionHistory = null,
            FocusHistoryViewModel? focusHistory = null)
        {
            LevelHistory = levelHistory;
            ScienceHistory = scienceHistory;
            GroupHistory = groupHistory;
            DirectionHistory = directionHistory;
            FocusHistory = focusHistory;
        }

        public readonly LevelHistoryViewModel? LevelHistory;
        public readonly ScienceHistoryViewModel? ScienceHistory;
        public readonly GroupHistoryViewModel? GroupHistory;
        public readonly DirectionHistoryViewModel? DirectionHistory;
        public readonly FocusHistoryViewModel? FocusHistory;
    }
}