using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Уровень")]
    [Index(nameof(Code), IsUnique = true)]
    public class LevelModel : ModelWithIdNameDescriptionCode
    {
        [Display(Name = "Уровни - направленности выбранного уровня")]
        [JsonPropertyName("LevelFocuss")]
        public List<LevelFocusModel>? LevelFocuss { get; set; }
    }
}