using EasyToEnter.ASP.Dependence;
using System.ComponentModel.DataAnnotations;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Наука"
    [Display(Name = "Наука")]
    public class ScienceModel : ModelWithIdNameDescription
    {
        List<GroupModel> Groups { get; set; }
    }
}