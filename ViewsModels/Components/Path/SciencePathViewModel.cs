namespace EasyToEnter.ASP.ViewsModels.Components.Path
{
    public class SciencePathViewModel : PathViewModel
    {
        public SciencePathViewModel(string scienceName, int levelId)
        {
            Name = scienceName;
            Href = $"/Applicant/ScienceSelection?level={levelId}";
        }
    }
}