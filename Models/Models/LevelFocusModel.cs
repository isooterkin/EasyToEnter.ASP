using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Уровень - Направленность"
    [Display(Name = "Уровень - Направленность")]
    [Index(nameof(LevelId), nameof(FocusId), IsUnique = true)]
    public class LevelFocusModel : ModelWithId
    {
        // Внешний ключ модели "Уровень"
        [Display(Name = "Уровень")]
        [Required(ErrorMessage = "Укажите уровень.")]
        public int LevelId { get; set; }
        [ForeignKey(nameof(LevelId))]
        [Display(Name = "Уровень")]
        public LevelModel? LevelModel { get; set; }

        // Внешний ключ модели "Направленность"
        [Display(Name = "Направленность")]
        [Required(ErrorMessage = "Укажите направленность.")]
        public int FocusId { get; set; }
        [ForeignKey(nameof(FocusId))]
        [Display(Name = "Направленность")]
        public FocusModel? FocusModel { get; set; }

        [NotMapped]
        [Display(Name = "Код")]
        public string FullCode => $"{FocusModel?.DirectionModel?.GroupModel?.Code}.{LevelModel?.Code}.{FocusModel?.DirectionModel?.Code}";
        
        [NotMapped]
        [Display(Name = "Наименование")]
        public string FullCodeName => $"{FullCode} {FocusModel?.DirectionModel?.Name}";

        [NotMapped]
        [Display(Name = "Наименование")]
        public string CodeName => $"{FullCode} {FocusModel?.Name}";
    }
}