using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

namespace EasyToEnter.ASP.Dependence
{
    public class ModelWithIdNameDescription : ModelWithId
    {
        // Наименование
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Укажите наименование.")]
        public string Name { set; get; }

        // Описание
        [Display(Name = "Описание")]
        public string? Description { set; get; }
    }
}