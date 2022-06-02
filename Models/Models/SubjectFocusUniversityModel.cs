using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Предмет направленности ВУЗа")]
    [Index(nameof(SubjectId), nameof(FocusUniversityId), IsUnique = true)]
    public class SubjectFocusUniversityModel : ModelWithId
    {
        [Display(Name = "Предмет")]
        [Required(ErrorMessage = "Укажите предмет.")]
        [JsonPropertyName("SubjectId")]
        public int SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [Display(Name = "Предмет")]
        [JsonPropertyName("SubjectModel")]
        public SubjectModel? SubjectModel { get; set; }



        [Display(Name = "Направленность ВУЗа")]
        [Required(ErrorMessage = "Укажите направленность ВУЗа.")]
        [JsonPropertyName("FocusUniversityId")]
        public int FocusUniversityId { get; set; }
        [ForeignKey(nameof(FocusUniversityId))]
        [Display(Name = "Направленность ВУЗа")]
        [JsonPropertyName("FocusUniversityModel")]
        public FocusUniversityModel? FocusUniversityModel { get; set; }



        [Required(ErrorMessage = "Укажите проходной балл.")]
        [Display(Name = "Проходной балл")]
        [JsonPropertyName("PassingGrade")]
        public int PassingGrade { get; set; }



        [Display(Name = "Предметы на замену выбранного предмета направленности вуза")]
        [JsonPropertyName("SubjectReplacements")]
        public List<SubjectReplacementModel>? SubjectReplacements { get; set; }
    }
}