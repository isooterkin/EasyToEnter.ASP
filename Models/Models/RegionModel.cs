using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Субъект"
    [Display(Name = "Субъект")]
    public class RegionModel: ModelWithIdName
    {
        // Лист моделей "Город", принадлежащих модели "Субъект"
        [Display(Name = "Города выбранного судбекта")]
        public List<CityModel>? Citys { get; set; }
    }
}