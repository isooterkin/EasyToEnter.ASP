using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Направленность ВУЗа")]
    [Index(nameof(UniversityId), nameof(LevelFocusId), IsUnique = true)]
    public class FocusUniversityModel: ModelWithId
    {
        [Display(Name = "ВУЗ")]
        [Required(ErrorMessage = "Укажите ВУЗ.")]
        [JsonPropertyName("UniversityId")]
        public int UniversityId { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [Display(Name = "ВУЗ")]
        [JsonPropertyName("UniversityModel")]
        public UniversityModel? UniversityModel { get; set; }



        [Display(Name = "Уровень - Направленность")]
        [Required(ErrorMessage = "Укажите уровень - направленность.")]
        [JsonPropertyName("LevelFocusId")]
        public int LevelFocusId { get; set; }
        [ForeignKey(nameof(LevelFocusId))]
        [Display(Name = "Уровень - Направленность")]
        [JsonPropertyName("LevelFocusModel")]
        public LevelFocusModel? LevelFocusModel { get; set; }



        [Display(Name = "Вариативности выбранной направленности ВУЗа")]
        [JsonPropertyName("Variabilitys")]
        public List<VariabilityModel>? Variabilitys { get; set; }



        [Display(Name = "Дисциплины выбранной направленности ВУЗа")]
        [JsonPropertyName("DisciplineFocusUniversitys")]
        public List<DisciplineFocusUniversityModel>? DisciplineFocusUniversitys { get; set; }



        [Display(Name = "Предметы выбранной направленности ВУЗа")]
        [JsonPropertyName("SubjectFocusUniversitys")]
        public List<SubjectFocusUniversityModel>? SubjectFocusUniversitys { get; set; }
    }
}