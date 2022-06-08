using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Вакансия - Профессия")]
    [Index(nameof(ProfessionId), nameof(VacancyId), IsUnique = true)]
    public class ProfessionVacancyModel: ModelWithId
    {
        [Display(Name = "Профессия")]
        [Required(ErrorMessage = "Укажите профессию.")]
        [JsonPropertyName(nameof(ProfessionId))]
        public int ProfessionId { get; set; }
        [ForeignKey(nameof(ProfessionId))]
        [Display(Name = "Профессия")]
        [JsonPropertyName(nameof(ProfessionModel))]
        public ProfessionModel? ProfessionModel { get; set; }



        [Display(Name = "Вакансия")]
        [Required(ErrorMessage = "Укажите вакансию.")]
        [JsonPropertyName(nameof(VacancyId))]
        public int VacancyId { get; set; }
        [ForeignKey(nameof(VacancyId))]
        [Display(Name = "Вакансия")]
        [JsonPropertyName(nameof(VacancyModel))]
        public VacancyModel? VacancyModel { get; set; }
    }
}