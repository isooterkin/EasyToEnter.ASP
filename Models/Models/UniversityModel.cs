using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "ВУЗ"
    [Display(Name = "ВУЗ")]
    public class UniversityModel: ModelWithIdNameDescription
    {
        [Required(ErrorMessage = "Укажите электронную почту.")]
        [Display(Name = "Электронная почта")]
        [EmailAddress(ErrorMessage = "Неверная электронная почта.")]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage = "Укажите адрес.")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        // Внешний ключ модели "Город"
        [Display(Name = "Город")]
        [Required(ErrorMessage = "Укажите город.")]
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        [Display(Name = "Город")]
        public CityModel? CityModel { get; set; }

        // Внешний ключ модели "Аккредитация"
        [Display(Name = "Аккредитация")]
        [Required(ErrorMessage = "Укажите аккредитацию.")]
        public int AccreditationId { get; set; }
        [ForeignKey(nameof(AccreditationId))]
        [Display(Name = "Аккредитация")]
        public AccreditationModel? AccreditationModel { get; set; }
    }
}