using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Избранная вариативность")]
    [Index(nameof(VariabilityId), nameof(PersonId), IsUnique = true)]
    public class VariabilityFavoritesModel: ModelWithId
    {
        [Display(Name = "Вариативность")]
        [Required(ErrorMessage = "Укажите вариативность.")]
        [JsonPropertyName(nameof(VariabilityId))]
        public int VariabilityId { get; set; }
        [ForeignKey(nameof(VariabilityId))]
        [Display(Name = "Вариативность")]
        [JsonPropertyName(nameof(VariabilityModel))]
        public VariabilityModel? VariabilityModel { get; set; }



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