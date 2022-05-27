namespace EasyToEnter.ASP.ViewsModels.Components.History
{
    public class GroupHistoryViewModel : HistoryViewModel
    {
        public GroupHistoryViewModel(string groupName, int levelId, int scienceId)
        {
            Name = groupName;
            Href = $"/Applicant/GroupSelection?level={levelId}&science={scienceId}";
        }
    }
}