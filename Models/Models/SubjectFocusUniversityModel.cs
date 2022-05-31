using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Предмет направленности ВУЗа"
    [Display(Name = "Предмет направленности ВУЗа")]
    [Index(nameof(SubjectId), nameof(FocusUniversityId), IsUnique = true)]
    public class SubjectFocusUniversityModel : ModelWithId
    {
        // Внешний ключ модели "Предмет"
        [Display(Name = "Предмет")]
        [Required(ErrorMessage = "Укажите предмет.")]
        public int SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [Display(Name = "Предмет")]
        public SubjectModel? SubjectModel { get; set; }

        // Внешний ключ модели "Направленность ВУЗа"
        [Display(Name = "Направленность ВУЗа")]
        [Required(ErrorMessage = "Укажите направленность ВУЗа.")]
        public int FocusUniversityId { get; set; }
        [ForeignKey(nameof(FocusUniversityId))]
        [Display(Name = "Направленность ВУЗа")]
        public FocusUniversityModel? FocusUniversityModel { get; set; }

        [Required(ErrorMessage = "Укажите проходной балл.")]
        [Display(Name = "Проходной балл")]
        public int PassingGrade { get; set; }

        // Лист моделей "Предмет замена", принадлежащих модели "Предмет направленности ВУЗа"
        [Display(Name = "Предметы на замену выбранного предмета направленности вуза")]
        public List<SubjectReplacementModel>? SubjectReplacements { get; set; }
    }
}