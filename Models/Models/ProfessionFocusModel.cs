using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Профессия - Направленность")]
    [Index(nameof(FocusId), nameof(ProfessionId), IsUnique = true)]
    public class ProfessionFocusModel: ModelWithId
    {
        [Display(Name = "Направленность")]
        [Required(ErrorMessage = "Укажите направленность.")]
        [JsonPropertyName("FocusId")]
        public int FocusId { get; set; }
        [ForeignKey(nameof(FocusId))]
        [Display(Name = "Направленность")]
        [JsonPropertyName("FocusModel")]
        public FocusModel? FocusModel { get; set; }



        [Display(Name = "Профессия")]
        [Required(ErrorMessage = "Укажите профессию.")]
        [JsonPropertyName("ProfessionId")]
        public int ProfessionId { get; set; }
        [ForeignKey(nameof(ProfessionId))]
        [Display(Name = "Профессия")]
        [JsonPropertyName("ProfessionModel")]
        public ProfessionModel? ProfessionModel { get; set; }
    }
}