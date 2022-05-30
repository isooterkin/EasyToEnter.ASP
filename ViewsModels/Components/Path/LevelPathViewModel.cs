namespace EasyToEnter.ASP.ViewsModels.Components.Path
{
    public class LevelPathViewModel : PathViewModel
    {
        public LevelPathViewModel(string levelName)
        {
            Name = levelName;
            Href = "/Applicant/LevelSelection";
        }
    }
}