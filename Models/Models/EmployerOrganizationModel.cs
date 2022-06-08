using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Сотрудник организации")]
    [Index(nameof(OrganizationId), nameof(PersonId), IsUnique = true)]
    public class EmployerOrganizationModel: ModelWithId
    {
        [Display(Name = "Организация")]
        [Required(ErrorMessage = "Укажите организацию.")]
        [JsonPropertyName(nameof(OrganizationId))]
        public int OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [Display(Name = "Организация")]
        [JsonPropertyName(nameof(OrganizationModel))]
        public OrganizationModel? OrganizationModel { get; set; }



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