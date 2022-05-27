namespace EasyToEnter.ASP.ViewsModels.Components.History
{
    public class ScienceHistoryViewModel : HistoryViewModel
    {
        public ScienceHistoryViewModel(string scienceName, int levelId)
        {
            Name = scienceName;
            Href = $"/Applicant/ScienceSelection?level={levelId}";
        }
    }
}