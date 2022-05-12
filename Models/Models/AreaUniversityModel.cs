using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Область - ВУЗ"
    [Display(Name = "Область - ВУЗ")]
    public class AreaUniversityModel: ModelWithId
    {
        // Внешний ключ модели "Область"
        [Display(Name = "Область")]
        [Required(ErrorMessage = "Укажите область.")]
        public int AreaId { get; set; }
        [ForeignKey(nameof(AreaId))]
        [Display(Name = "Область")]
        public AreaModel? AreaModel { get; set; }


        // Внешний ключ модели "ВУЗ"
        [Display(Name = "ВУЗ")]
        [Required(ErrorMessage = "Укажите ВУЗ.")]
        public int UniversityId { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [Display(Name = "ВУЗ")]
        public UniversityModel? UniversityModel { get; set; }
    }
}