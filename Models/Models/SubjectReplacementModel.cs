using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Предмет на замену")]
    [Index(nameof(SubjectId), nameof(SubjectFocusUniversityId), IsUnique = true)]
    public class SubjectReplacementModel: ModelWithId
    {
        [Display(Name = "Предмет")]
        [Required(ErrorMessage = "Укажите предмет.")]
        [JsonPropertyName("SubjectId")]
        public int SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [Display(Name = "Предмет")]
        [JsonPropertyName("SubjectModel")]
        public SubjectModel? SubjectModel { get; set; }



        [Display(Name = "Предмет направленности ВУЗа")]
        [Required(ErrorMessage = "Укажите предмет направленности ВУЗа.")]
        [JsonPropertyName("SubjectFocusUniversityId")]
        public int SubjectFocusUniversityId { get; set; }
        [ForeignKey(nameof(SubjectFocusUniversityId))]
        [Display(Name = "Предмет направленности ВУЗа")]
        [JsonPropertyName("SubjectFocusUniversityModel")]
        public SubjectFocusUniversityModel? SubjectFocusUniversityModel { get; set; }



        [Required(ErrorMessage = "Укажите проходной балл.")]
        [Display(Name = "Проходной балл")]
        [JsonPropertyName("PassingGrade")]
        public int PassingGrade { get; set; }
    }
}