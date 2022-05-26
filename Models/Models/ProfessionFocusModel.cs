using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Профессия - Направленность"
    [Display(Name = "Профессия - Направленность")]
    [Index(nameof(FocusId), nameof(ProfessionId), IsUnique = true)]
    public class ProfessionFocusModel: ModelWithId
    {
        // Внешний ключ модели "Направленность"
        [Display(Name = "Направленность")]
        [Required(ErrorMessage = "Укажите направленность.")]
        public int FocusId { get; set; }
        [ForeignKey(nameof(FocusId))]
        [Display(Name = "Направленность")]
        public FocusModel? FocusModel { get; set; }

        // Внешний ключ модели "Профессия"
        [Display(Name = "Профессия")]
        [Required(ErrorMessage = "Укажите профессию.")]
        public int ProfessionId { get; set; }
        [ForeignKey(nameof(ProfessionId))]
        [Display(Name = "Профессия")]
        public ProfessionModel? ProfessionModel { get; set; }
    }
}