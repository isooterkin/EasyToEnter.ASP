using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Область - Направленность")]
    [Index(nameof(AreaId), nameof(FocusId), IsUnique = true)]
    public class AreaFocusModel: ModelWithId
    {
        [Display(Name = "Область")]
        [Required(ErrorMessage = "Укажите область.")]
        [JsonPropertyName("AreaId")]
        public int AreaId { get; set; }
        [ForeignKey(nameof(AreaId))]
        [Display(Name = "Область")]
        [JsonPropertyName("AreaModel")]
        public AreaModel? AreaModel { get; set; }



        [Display(Name = "Направленность")]
        [Required(ErrorMessage = "Укажите направленность.")]
        [JsonPropertyName("FocusId")]
        public int FocusId { get; set; }
        [ForeignKey(nameof(FocusId))]
        [Display(Name = "Направленность")]
        [JsonPropertyName("FocusModel")]
        public FocusModel? FocusModel { get; set; }
    }
}