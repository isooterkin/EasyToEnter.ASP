using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Вакансия")]
    public class VacancyModel: ModelWithIdNameDescription
    {
        [Display(Name = "Зарплата")]
        [Required(ErrorMessage = "Укажите зарплату.")]
        [JsonPropertyName(nameof(Wages))]
        public int Wages { get; set; }



        [Display(Name = "Организация")]
        [Required(ErrorMessage = "Укажите организацию.")]
        [JsonPropertyName(nameof(OrganizationId))]
        public int OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [Display(Name = "Организация")]
        [JsonPropertyName(nameof(OrganizationModel))]
        public OrganizationModel? OrganizationModel { get; set; }
    }
}