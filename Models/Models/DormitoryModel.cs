using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Общежитие"
    [Display(Name = "Общежитие")]
    [Index(nameof(AddressId), nameof(UniversityId), IsUnique = true)]
    public class DormitoryModel: ModelWithIdName
    {
        // Внешний ключ модели "Адрес"
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Укажите адрес.")]
        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        [Display(Name = "Адрес")]
        public AddressModel? AddressModel { get; set; }

        // Внешний ключ модели "ВУЗ"
        [Display(Name = "ВУЗ")]
        [Required(ErrorMessage = "Укажите ВУЗ.")]
        public int UniversityId { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [Display(Name = "ВУЗ")]
        public UniversityModel? UniversityModel { get; set; }

        [Display(Name = "Контактный телефон")]
        [Phone(ErrorMessage = "Неверный телефон.")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Размер платы")]
        public int? Amount { get; set; }
    }
}