using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Субъект")]
    public class RegionModel: ModelWithIdName
    {
        [Display(Name = "Города выбранного судбекта")]
        [JsonPropertyName("Citys")]
        public List<CityModel>? Citys { get; set; }
    }
}