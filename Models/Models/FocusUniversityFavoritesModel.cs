using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Направленность ВУЗа - Избранная")]
    [Index(nameof(FocusUniversityId), nameof(PersonId), IsUnique = true)]
    public class FocusUniversityFavoritesModel: ModelWithId
    {
        [Display(Name = "Направленность ВУЗа")]
        [Required(ErrorMessage = "Укажите направленность ВУЗа.")]
        [JsonPropertyName(nameof(FocusUniversityId))]
        public int FocusUniversityId { get; set; }
        [ForeignKey(nameof(FocusUniversityId))]
        [Display(Name = "Направленность ВУЗа")]
        [JsonPropertyName(nameof(FocusUniversityModel))]
        public FocusUniversityModel? FocusUniversityModel { get; set; }



        [Display(Name = "Пользователь")]
        [Required(ErrorMessage = "Укажите пользователя.")]
        [JsonPropertyName(nameof(PersonId))]
        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        [Display(Name = "Пользователь")]
        [JsonPropertyName(nameof(PersonModel))]
        public PersonModel? PersonModel { get; set; }
    }
}