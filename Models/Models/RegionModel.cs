using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Субъект")]
    public class RegionModel: ModelWithIdName
    {
        [Display(Name = "Города выбранного судбекта")]
        [JsonPropertyName("Citys")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public List<CityModel>? Citys { get; set; }
    }
}