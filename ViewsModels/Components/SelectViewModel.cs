namespace EasyToEnter.ASP.ViewsModels.Components
{
    public class SelectViewModel
    {
        public readonly string Name;
        public readonly string Title;
        public readonly List<SelectListItemSubtext> SelectListItem;

        public SelectViewModel(string name, string title, List<SelectListItemSubtext> selectListItem)
        {
            Name = name;
            Title = title;
            SelectListItem = selectListItem;
        }
    }
}