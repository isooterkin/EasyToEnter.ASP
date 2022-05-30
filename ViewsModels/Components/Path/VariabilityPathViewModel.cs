namespace EasyToEnter.ASP.ViewsModels.Components.Path
{
    public class VariabilityPathViewModel : PathViewModel
    {
        public readonly int UniversityId;

        public VariabilityPathViewModel(string variabilityName, int levelFocusId, int universityId)
        {
            Name = variabilityName;
            Href = $"/Applicant/VariabilitySelection?levelFocus={levelFocusId}";
            UniversityId = universityId;
        }
    }
}