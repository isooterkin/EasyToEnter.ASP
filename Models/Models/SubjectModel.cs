using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Предмет")]
    public class SubjectModel: ModelWithIdName
    {
        [Display(Name = "Предметы на замену выбранного предмета")]
        [JsonPropertyName("SubjectReplacements")]
        public List<SubjectReplacementModel>? SubjectReplacements { get; set; }
    }
}