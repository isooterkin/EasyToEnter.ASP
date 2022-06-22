using EasyToEnter.ASP.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    // Модель "ВУЗ"
    [Display(Name = "ВУЗ")]
    public class UniversityFavoritesViewModel
    {
        [Display(Name = "ВУЗ")]
        [JsonPropertyName("University")]
        public UniversityModel University { get; set; }



        [Display(Name = "Избранная")]
        [JsonPropertyName("Favorites")]
        public bool Favorites { get; set; } = false;
    }
}