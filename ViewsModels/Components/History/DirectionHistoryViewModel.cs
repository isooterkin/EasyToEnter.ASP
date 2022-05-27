namespace EasyToEnter.ASP.ViewsModels.Components.History
{
    public class DirectionHistoryViewModel : HistoryViewModel
    {
        public DirectionHistoryViewModel(string directionName, int levelId, int groupId)
        {
            Name = directionName;
            Href = $"/Applicant/DirectionSelection?level={levelId}&group={groupId}";
        }
    }
}