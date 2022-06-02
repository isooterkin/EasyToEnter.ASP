using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Направленность")]
    public class FocusModel : ModelWithIdNameDescription
    {
        [Display(Name = "Направление")]
        [Required(ErrorMessage = "Укажите направление.")]
        [JsonPropertyName("DirectionId")]
        public int DirectionId { get; set; }
        [ForeignKey(nameof(DirectionId))]
        [Display(Name = "Направление")]
        [JsonPropertyName("DirectionModel")]
        public DirectionModel? DirectionModel { get; set; }



        [Display(Name = "Области - направленности выбранной направленности")]
        [JsonPropertyName("AreaFocuss")]
        public List<AreaFocusModel>? AreaFocuss { get; set; }

        

        [Display(Name = "Уровни - направленности выбранной направленности")]
        [JsonPropertyName("LevelFocuss")]
        public List<LevelFocusModel>? LevelFocuss { get; set; }



        [Display(Name = "Профессии - направленности выбранной направленности")]
        [JsonPropertyName("ProfessionFocuss")]
        public List<ProfessionFocusModel>? ProfessionFocuss { get; set; }
    }
}