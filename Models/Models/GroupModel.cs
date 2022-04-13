using EasyToEnter.ASP.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Группа"
    [Display(Name = "Группа")]
    public class GroupModel : ModelWithIdNameDescriptionCode
    {
        // Внешний ключ модели "Наука"
        [Display(Name = "Наука")]
        [Required(ErrorMessage = "Укажите науку.")]
        public int ScienceId { get; set; }
        [ForeignKey(nameof(ScienceId))]
        [Display(Name = "Наука")]
        public ScienceModel? ScienceModel { get; set; }

        List<DirectionModel> Directions { get; set; }
    }
}