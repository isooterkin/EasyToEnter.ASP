using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Профессия")]
    public class ProfessionModel: ModelWithIdNameDescription
    {
        [Display(Name = "Тип профессии")]
        [Required(ErrorMessage = "Укажите тип профессии.")]
        [JsonPropertyName("TypeProfessionId")]
        public int TypeProfessionId { get; set; }
        [ForeignKey(nameof(TypeProfessionId))]
        [Display(Name = "Тип профессии")]
        public TypeProfessionModel? TypeProfessionModel { get; set; }



        // !!! берем ЗП всех вакансий и находим среднее!!!
        [NotMapped]
        [Display(Name = "Средняя ЗП")]
        [JsonPropertyName("AverageWage")]
        public int? AverageWage => 0;
    }
}