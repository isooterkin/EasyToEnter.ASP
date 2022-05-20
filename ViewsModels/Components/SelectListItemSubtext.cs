using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyToEnter.ASP.ViewsModels.Components
{
    public class SelectListItemSubtext: SelectListItem
    {
        private string? SubtextPrivate { get; set; }
        public string? Subtext 
        { 
            get => $"({SubtextPrivate})";
            set => SubtextPrivate = value;
        }
    }
}