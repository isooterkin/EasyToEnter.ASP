using EasyToEnter.ASP.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Группа"
    [Display(Name = "Группа")]
    [Index(nameof(Code), IsUnique = true)]
    public class GroupModel : ModelWithIdNameDescriptionCode
    {
        // Внешний ключ модели "Наука"
        [Display(Name = "Наука")]
        [Required(ErrorMessage = "Укажите науку.")]
        public int ScienceId { get; set; }
        [ForeignKey(nameof(ScienceId))]
        [Display(Name = "Наука")]
        public ScienceModel? ScienceModel { get; set; }

        // Лист моделей "Направление", принадлежащих модели "Группа"
        [Display(Name = "Направления выбранной группы")]
        public List<DirectionModel>? Directions { get; set; }
    }
}