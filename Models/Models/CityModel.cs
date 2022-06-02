using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Город")]
    public class CityModel : ModelWithIdName
    {
        [Display(Name = "Субъект")]
        [Required(ErrorMessage = "Укажите субъект.")]
        [JsonPropertyName("RegionId")]
        public int RegionId { get; set; }
        [ForeignKey(nameof(RegionId))]
        [Display(Name = "Субъект")]
        [JsonPropertyName("RegionModel")]
        public RegionModel? RegionModel { get; set; }
    }
}