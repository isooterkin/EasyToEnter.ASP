namespace EasyToEnter.ASP.ViewsModels.Components.History
{
    public class LevelHistoryViewModel: HistoryViewModel
    {
        public LevelHistoryViewModel(string levelName)
        {
            Name = levelName;
            Href = "/Applicant/LevelSelection";
        }
    }
}