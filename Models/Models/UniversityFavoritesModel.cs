using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Избранный вуз")]
    [Index(nameof(UniversityId), nameof(PersonId), IsUnique = true)]
    public class UniversityFavoritesModel : ModelWithId
    {
        [Display(Name = "ВУЗ")]
        [Required(ErrorMessage = "Укажите ВУЗ.")]
        [JsonPropertyName("UniversityId")]
        public int UniversityId { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [Display(Name = "ВУЗ")]
        [JsonPropertyName("UniversityModel")]
        public UniversityModel? UniversityModel { get; set; }



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