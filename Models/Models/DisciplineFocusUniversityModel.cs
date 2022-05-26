using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Дисциплина направленности ВУЗа"
    [Display(Name = "Дисциплина направленности ВУЗа")]
    [Index(nameof(FocusUniversityId), nameof(DisciplineId), IsUnique = true)]
    public class DisciplineFocusUniversityModel: ModelWithId
    {
        // Внешний ключ модели "Направленность ВУЗа"
        [Display(Name = "Направленность ВУЗа")]
        [Required(ErrorMessage = "Укажите направленность ВУЗа.")]
        public int FocusUniversityId { get; set; }
        [ForeignKey(nameof(FocusUniversityId))]
        [Display(Name = "Направленность ВУЗа")]
        public FocusUniversityModel? FocusUniversityModel { get; set; }

        // Внешний ключ модели "Дисциплина"
        [Display(Name = "Дисциплина")]
        [Required(ErrorMessage = "Укажите дисциплину.")]
        public int DisciplineId { get; set; }
        [ForeignKey(nameof(DisciplineId))]
        [Display(Name = "Дисциплина")]
        public DisciplineModel? DisciplineModel { get; set; }

        [Required(ErrorMessage = "Укажите зачетную единицу трудоемкости.")]
        [Display(Name = "Зачетная единица трудоемкости")]
        public int DisciplineCredit { get; set; }
    }
}