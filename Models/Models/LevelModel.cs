using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Уровень"
    [Display(Name = "Уровень")]
    [Index(nameof(Code), IsUnique = true)]
    public class LevelModel : ModelWithIdNameDescriptionCode
    {
        // Лист моделей "Уровень - Направленность", принадлежащих модели "Уровень"
        [Display(Name = "Уровни - направленности выбранного уровня")]
        public List<LevelFocusModel>? LevelFocuss { get; set; }
    }
}