using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Вакансия")]
    public class VacancyModel: ModelWithId
    {
        [Display(Name = "Зарплата")]
        [Required(ErrorMessage = "Укажите зарплату.")]
        [JsonPropertyName(nameof(Wages))]
        public int Wages { get; set; }



        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Укажите наименование.")]
        [JsonPropertyName(nameof(Name))]
        public string Name { set; get; }



        [Display(Name = "Описание")]
        [JsonPropertyName(nameof(Description))]
        public string? Description { set; get; }



        [Display(Name = "Организация")]
        [Required(ErrorMessage = "Укажите организацию.")]
        [JsonPropertyName(nameof(OrganizationId))]
        public int OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [Display(Name = "Организация")]
        [JsonPropertyName(nameof(OrganizationModel))]
        public OrganizationModel? OrganizationModel { get; set; }



        [Display(Name = "Профессия")]
        [Required(ErrorMessage = "Укажите профессию.")]
        [JsonPropertyName(nameof(ProfessionId))]
        public int ProfessionId { get; set; }
        [ForeignKey(nameof(ProfessionId))]
        [Display(Name = "Профессия")]
        [JsonPropertyName(nameof(ProfessionModel))]
        public ProfessionModel? ProfessionModel { get; set; }



        [Display(Name = "Избранные вакансии")]
        [JsonPropertyName(nameof(VacancyFavoritess))]
        public List<VacancyFavoritesModel>? VacancyFavoritess { get; set; }
    }
}