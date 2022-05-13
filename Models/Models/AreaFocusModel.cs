using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Область - Направленность"
    [Display(Name = "Область - Направленность")]
    [Index(nameof(AreaId), nameof(FocusId), IsUnique = true)]
    public class AreaFocusModel: ModelWithId
    {
        // Внешний ключ модели "Область"
        [Display(Name = "Область")]
        [Required(ErrorMessage = "Укажите область.")]
        public int AreaId { get; set; }
        [ForeignKey(nameof(AreaId))]
        [Display(Name = "Область")]
        public AreaModel? AreaModel { get; set; }

        // Внешний ключ модели "Направленность"
        [Display(Name = "Направленность")]
        [Required(ErrorMessage = "Укажите направленность.")]
        public int FocusId { get; set; }
        [ForeignKey(nameof(FocusId))]
        [Display(Name = "Направленность")]
        public FocusModel? FocusModel { get; set; }
    }
}