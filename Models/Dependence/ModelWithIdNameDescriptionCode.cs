using EasyToEnter.ASP.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

namespace EasyToEnter.ASP.Models.Dependence
{
    public class ModelWithIdNameDescriptionCode : ModelWithIdNameDescription
    {
        // Код
        [Display(Name = "Код")]
        [Code(ErrorMessage = "Недопустимый код.")]
        [Required(ErrorMessage = "Укажите код.")]
        [JsonPropertyName("Code")]
        public string Code { set; get; }
    }
}