using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Профессия"
    [Display(Name = "Профессия")]
    public class ProfessionModel: ModelWithIdNameDescription
    {
        // Внешний ключ модели "Тип профессии"
        [Display(Name = "Тип профессии")]
        [Required(ErrorMessage = "Укажите тип профессии.")]
        public int TypeProfessionId { get; set; }
        [ForeignKey(nameof(TypeProfessionId))]
        [Display(Name = "Тип профессии")]
        public TypeProfessionModel? TypeProfessionModel { get; set; }

        // !!! берем ЗП всех вакансий и находим среднее!!!
        [NotMapped]
        [Display(Name = "Средняя ЗП")]
        public int? AverageWage => 0;
    }
}