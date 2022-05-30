namespace EasyToEnter.ASP.ViewsModels.Components.Path
{
    public class FocusPathViewModel : PathViewModel
    {
        public FocusPathViewModel(string focusName, int levelId, int directionId)
        {
            Name = focusName;
            Href = $"/Applicant/FocusSelection?level={levelId}&direction={directionId}";
        }
    }
}
