using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Предмет"
    [Display(Name = "Предмет")]
    public class SubjectModel: ModelWithIdName
    {
        // Лист моделей "Предмет на замену", принадлежащих модели "Предмет"
        [Display(Name = "Предметы на замену выбранного предмета")]
        public List<SubjectReplacementModel>? SubjectReplacements { get; set; }
    }
}