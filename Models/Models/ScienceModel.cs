using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Наука"
    [Display(Name = "Наука")]
    public class ScienceModel : ModelWithIdNameDescription
    {
        // Лист моделей "Группа", принадлежащих модели "Наука"
        [Display(Name = "Группы выбранной науки")]
        public List<GroupModel>? Groups { get; set; }
    }
}