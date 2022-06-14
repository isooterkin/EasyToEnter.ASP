using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Организация")]
    public class OrganizationModel: ModelWithIdNameDescription
    {
        [Display(Name = "Контактный телефон")]
        [Required(ErrorMessage = "Укажите контактный номер.")]
        [Phone(ErrorMessage = "Неверный телефон.")]
        [JsonPropertyName(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }



        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage = "Укажите электронную почту.")]
        [EmailAddress(ErrorMessage = "Неверная электронная почта.")]
        [JsonPropertyName(nameof(EmailAddress))]
        public string EmailAddress { get; set; }



        [Display(Name = "Сотрудники ВУЗа")]
        [JsonPropertyName(nameof(EmployerOrganizations))]
        public List<EmployerOrganizationModel>? EmployerOrganizations { get; set; }



        [Display(Name = "Вакансии организации")]
        [JsonPropertyName(nameof(Vacancys))]
        public List<VacancyModel>? Vacancys { get; set; }
    }
}