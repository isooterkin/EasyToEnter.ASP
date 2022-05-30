namespace EasyToEnter.ASP.ViewsModels.Components.Path
{
    public class VariabilityPathViewModel : PathViewModel
    {
        public VariabilityPathViewModel(string variabilityName, int levelFocusId)
        {
            Name = variabilityName;
            Href = $"/Applicant/VariabilitySelection?levelFocus={levelFocusId}";
        }
    }
}