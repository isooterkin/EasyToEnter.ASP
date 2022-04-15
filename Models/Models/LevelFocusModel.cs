using EasyToEnter.ASP.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
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
        public string FullCode => FocusModel?.DirectionModel?.GroupModel?.Code + "." + LevelModel?.Code + "." + FocusModel?.DirectionModel?.Code;
        public string FullCodeName => FullCode + " " + FocusModel?.DirectionModel?.Name;
    }
}