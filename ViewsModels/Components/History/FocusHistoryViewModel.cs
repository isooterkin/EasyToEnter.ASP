namespace EasyToEnter.ASP.ViewsModels.Components.History
{
    public class FocusHistoryViewModel : HistoryViewModel
    {
        public FocusHistoryViewModel(string focusName, int levelId, int directionId)
        {
            Name = focusName;
            Href = $"/Applicant/DirectionSelection?level={levelId}&group={directionId}";
        }
    }
}