using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Специальность - ВУЗ"
    [Display(Name = "Специальность - ВУЗ")]
    public class SpecializationUniversityModel: ModelWithId
    {
        // Внешний ключ модели "Специальность"
        [Display(Name = "Специальность")]
        [Required(ErrorMessage = "Укажите специальность.")]
        public int SpecializationId { get; set; }
        [ForeignKey(nameof(SpecializationId))]
        [Display(Name = "Специальность")]
        public SpecializationModel? SpecializationModel { get; set; }


        // Внешний ключ модели "ВУЗ"
        [Display(Name = "ВУЗ")]
        [Required(ErrorMessage = "Укажите ВУЗ.")]
        public int UniversityId { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [Display(Name = "ВУЗ")]
        public UniversityModel? UniversityModel { get; set; }
    }
}