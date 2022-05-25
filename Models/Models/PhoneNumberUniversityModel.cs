using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Контактный телефон"
    [Display(Name = "Контактный телефон")]
    [Index(nameof(UniversityId), nameof(PhoneNumber), IsUnique = true)]
    public class PhoneNumberUniversityModel : ModelWithId
    {
        // Внешний ключ модели "ВУЗ"
        [Display(Name = "ВУЗ")]
        [Required(ErrorMessage = "Укажите ВУЗ.")]
        public int UniversityId { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [Display(Name = "ВУЗ")]
        public UniversityModel? UniversityModel { get; set; }

        [Required(ErrorMessage = "Укажите контактный телефон.")]
        [Display(Name = "Контактный телефон")]
        [Phone(ErrorMessage = "Неверный телефон.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите назначение.")]
        [Display(Name = "Назначение")]
        public string Appointment { get; set; } = "Для абитуриентов";
    }
}