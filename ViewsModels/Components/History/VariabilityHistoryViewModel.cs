namespace EasyToEnter.ASP.ViewsModels.Components.History
{
    public class VariabilityHistoryViewModel : HistoryViewModel
    {
        public VariabilityHistoryViewModel(string variabilityName, int levelFocusId)
        {
            Name = variabilityName;
            Href = $"/Applicant/VariabilitySelection?levelFocus={levelFocusId}";
        }
    }
}