using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Город"
    [Display(Name = "Город")]
    public class CityModel : ModelWithIdName
    {
        // Внешний ключ модели "Субъект"
        [Display(Name = "Субъект")]
        [Required(ErrorMessage = "Укажите субъект.")]
        public int RegionId { get; set; }
        [ForeignKey(nameof(RegionId))]
        [Display(Name = "Субъект")]
        public RegionModel? RegionModel { get; set; }
    }
}