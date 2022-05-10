using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Направленность"
    [Display(Name = "Направленность")]
    public class FocusModel : ModelWithIdNameDescription
    {
        // Внешний ключ модели "Направление"
        [Display(Name = "Направление")]
        [Required(ErrorMessage = "Укажите направление.")]
        public int DirectionId { get; set; }
        [ForeignKey(nameof(DirectionId))]
        [Display(Name = "Направление")]
        public DirectionModel? DirectionModel { get; set; }

        // Лист моделей "Уровень - Направленность", принадлежащих модели "Направленность"
        [Display(Name = "Уровни - направленности выбранной направленности")]
        public List<LevelFocusModel>? LevelFocuss { get; set; }
    }
}