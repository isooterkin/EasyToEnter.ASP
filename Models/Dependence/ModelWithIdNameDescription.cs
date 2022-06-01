using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Dependence
{
    public class ModelWithIdNameDescription : ModelWithIdName
    {
        // Описание
        [Display(Name = "Описание")]
        [JsonPropertyName("Description")]
        public string? Description { set; get; }
    }
}