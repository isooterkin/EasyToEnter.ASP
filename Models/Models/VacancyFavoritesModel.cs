using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Избранная вакансия")]
    [Index(nameof(VacancyId), nameof(PersonId), IsUnique = true)]
    public class VacancyFavoritesModel : ModelWithId
    {
        [Display(Name = "Вакансия")]
        [Required(ErrorMessage = "Укажите вакансию.")]
        [JsonPropertyName(nameof(VacancyId))]
        public int VacancyId { get; set; }
        [ForeignKey(nameof(VacancyId))]
        [Display(Name = "Вакансия")]
        [JsonPropertyName(nameof(VacancyModel))]
        public VacancyModel? VacancyModel { get; set; }



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