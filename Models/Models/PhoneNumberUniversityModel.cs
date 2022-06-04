using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Контактный телефон")]
    [Index(nameof(UniversityId), nameof(PhoneNumber), IsUnique = true)]
    public class PhoneNumberUniversityModel : ModelWithId
    {
        [Display(Name = "ВУЗ")]
        [Required(ErrorMessage = "Укажите ВУЗ.")]
        [JsonPropertyName("UniversityId")]
        public int UniversityId { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [Display(Name = "ВУЗ")]
        [JsonPropertyName("UniversityModel")]
        public UniversityModel? UniversityModel { get; set; }



        [Required(ErrorMessage = "Укажите контактный телефон.")]
        [Display(Name = "Контактный телефон")]
        [Phone(ErrorMessage = "Неверный телефон.")]
        [JsonPropertyName("PhoneNumber")]
        public string PhoneNumber { get; set; }



        [Required(ErrorMessage = "Укажите назначение.")]
        [Display(Name = "Назначение")]
        [JsonPropertyName("Appointment")]
        public string Appointment { get; set; }
    }
}