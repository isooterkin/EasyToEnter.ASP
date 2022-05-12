using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Направленность ВУЗа"
    [Display(Name = "Направленность ВУЗа")]
    [Index(nameof(LevelFocusId), nameof(UniversityId), IsUnique = true)]
    public class FocusUniversityModel : ModelWithId
    {
        // Внешний ключ модели "Уровень - Направленность"
        [Display(Name = "Уровень - Направленность")]
        [Required(ErrorMessage = "Укажите уровень - направленность.")]
        public int LevelFocusId { get; set; }
        [ForeignKey(nameof(LevelFocusId))]
        [Display(Name = "Уровень - Направленность")]
        public LevelFocusModel? LevelFocusModel { get; set; }

        // Внешний ключ модели "ВУЗ"
        [Display(Name = "ВУЗ")]
        [Required(ErrorMessage = "Укажите ВУЗ.")]
        public int UniversityId { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [Display(Name = "ВУЗ")]
        public UniversityModel? UniversityModel { get; set; }
    }
}