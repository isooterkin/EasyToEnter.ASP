using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Предмет на замену"
    [Display(Name = "Предмет на замену")]
    [Index(nameof(SubjectId), nameof(SubjectFocusUniversityId), IsUnique = true)]
    public class SubjectReplacementModel: ModelWithId
    {
        // Внешний ключ модели "Предмет"
        [Display(Name = "Предмет")]
        [Required(ErrorMessage = "Укажите предмет.")]
        public int SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [Display(Name = "Предмет")]
        public SubjectModel? SubjectModel { get; set; }

        // Внешний ключ модели "Предмет направленности ВУЗа"
        [Display(Name = "Предмет направленности ВУЗа")]
        [Required(ErrorMessage = "Укажите предмет направленности ВУЗа.")]
        public int SubjectFocusUniversityId { get; set; }
        [ForeignKey(nameof(SubjectFocusUniversityId))]
        [Display(Name = "Предмет направленности ВУЗа")]
        public SubjectFocusUniversityModel? SubjectFocusUniversityModel { get; set; }

        [Required(ErrorMessage = "Укажите проходной балл.")]
        [Display(Name = "Проходной балл")]
        public int PassingGrade { get; set; }
    }
}