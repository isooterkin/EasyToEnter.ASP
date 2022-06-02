using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Наука")]
    public class ScienceModel : ModelWithIdNameDescription
    {
        [Display(Name = "Группы выбранной науки")]
        [JsonPropertyName("Groups")]
        public List<GroupModel>? Groups { get; set; }
    }
}