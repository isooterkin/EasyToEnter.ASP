using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Дисциплина направленности ВУЗа")]
    [Index(nameof(FocusUniversityId), nameof(DisciplineId), IsUnique = true)]
    public class DisciplineFocusUniversityModel: ModelWithId
    {
        [Display(Name = "Направленность ВУЗа")]
        [Required(ErrorMessage = "Укажите направленность ВУЗа.")]
        [JsonPropertyName("FocusUniversityId")]
        public int FocusUniversityId { get; set; }
        [ForeignKey(nameof(FocusUniversityId))]
        [Display(Name = "Направленность ВУЗа")]
        [JsonPropertyName("FocusUniversityModel")]
        public FocusUniversityModel? FocusUniversityModel { get; set; }



        [Display(Name = "Дисциплина")]
        [Required(ErrorMessage = "Укажите дисциплину.")]
        [JsonPropertyName("DisciplineId")]
        public int DisciplineId { get; set; }
        [ForeignKey(nameof(DisciplineId))]
        [Display(Name = "Дисциплина")]
        [JsonPropertyName("DisciplineModel")]
        public DisciplineModel? DisciplineModel { get; set; }



        [Required(ErrorMessage = "Укажите зачетную единицу трудоемкости.")]
        [Display(Name = "Зачетная единица трудоемкости")]
        [JsonPropertyName("DisciplineCredit")]
        public int DisciplineCredit { get; set; }
    }
}