using System.ComponentModel.DataAnnotations;

namespace EasyToEnter.ASP.Models.Dependence
{
    public class ModelWithIdNameDescription : ModelWithIdName
    {
        // Описание
        [Display(Name = "Описание")]
        public string? Description { set; get; }
    }
}