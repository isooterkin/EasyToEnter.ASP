using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;

namespace EasyToEnter.ASP.Dependence
{
    public class ModelWithIdNameDescription : ModelWithIdName
    {
        // Описание
        [Display(Name = "Описание")]
        public string? Description { set; get; }
    }
}