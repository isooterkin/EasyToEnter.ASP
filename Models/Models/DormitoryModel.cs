using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Общежитие"
    [Display(Name = "Общежитие")]
    public class DormitoryModel: ModelWithIdName
    {
        [Required(ErrorMessage = "Укажите адрес.")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        // Внешний ключ модели "ВУЗ"
        [Display(Name = "ВУЗ")]
        [Required(ErrorMessage = "Укажите ВУЗ.")]
        public int UniversityId { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [Display(Name = "ВУЗ")]
        public UniversityModel? UniversityModel { get; set; }
    }
}