using EasyToEnter.ASP.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    // Модель "Вариативность"
    [Display(Name = "Вариативность")]
    public class VariabilityViewModel: VariabilityModel
    {
        [Display(Name = "Избранная")]
        [JsonPropertyName("Favorites")]
        public bool Favorites { get; set; } = false;
    }
}