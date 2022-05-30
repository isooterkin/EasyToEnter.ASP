namespace EasyToEnter.ASP.ViewsModels.Components.Path
{
    public class GroupPathViewModel : PathViewModel
    {
        public GroupPathViewModel(string groupName, int levelId, int scienceId)
        {
            Name = groupName;
            Href = $"/Applicant/GroupSelection?level={levelId}&science={scienceId}";
        }
    }
}