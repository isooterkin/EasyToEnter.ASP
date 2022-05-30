namespace EasyToEnter.ASP.ViewsModels.Components.Path
{
    public class DirectionPathViewModel : PathViewModel
    {
        public DirectionPathViewModel(string directionName, int levelId, int groupId)
        {
            Name = directionName;
            Href = $"/Applicant/DirectionSelection?level={levelId}&group={groupId}";
        }
    }
}