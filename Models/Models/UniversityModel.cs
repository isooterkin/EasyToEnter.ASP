using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "ВУЗ"
    [Display(Name = "ВУЗ")]
    public class UniversityModel: ModelWithIdNameDescription
    {
        [Required(ErrorMessage = "Укажите aббревиатурe.")]
        [Display(Name = "Аббревиатура")]
        public string Abbreviation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите электронную почту.")]
        [Display(Name = "Электронная почта")]
        [EmailAddress(ErrorMessage = "Неверная электронная почта.")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите наличие военной кафедры.")]
        [Display(Name = "Военная кафедра")]
        public bool MilitaryDepartment { get; set; } = false;

        [Required(ErrorMessage = "Укажите сайт.")]
        [Display(Name = "Сайт")]
        [Url(ErrorMessage = "Неверная ссылка.")]
        public string Website { get; set; } = string.Empty;

        // Внешний ключ модели "Адрес"
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Укажите адрес.")]
        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        [Display(Name = "Адрес")]
        public AddressModel? AddressModel { get; set; }

        // Внешний ключ модели "Аккредитация"
        [Display(Name = "Аккредитация")]
        [Required(ErrorMessage = "Укажите аккредитацию.")]
        public int AccreditationId { get; set; }
        [ForeignKey(nameof(AccreditationId))]
        [Display(Name = "Аккредитация")]
        public AccreditationModel? AccreditationModel { get; set; }

        // Лист моделей "Специальность - ВУЗ", принадлежащих модели "ВУЗ"
        [Display(Name = "Специальности - вуза выбранного вуза")]
        public List<SpecializationUniversityModel>? SpecializationUniversitys { get; set; }

        // Лист моделей "Общежитие", принадлежащих модели "ВУЗ"
        [Display(Name = "Общежития выбранного вуза")]
        public List<DormitoryModel>? Dormitorys { get; set; }

        // Лист моделей "Контактный телефон", принадлежащих модели "ВУЗ"
        [Display(Name = "Контактные телефоны выбранного вуза")]
        public List<PhoneNumberUniversityModel>? PhoneNumbers { get; set; }
    }
}