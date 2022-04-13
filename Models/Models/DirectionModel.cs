using EasyToEnter.ASP.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Направление"
    [Display(Name = "Направление")]
    public class DirectionModel : ModelWithIdNameDescriptionCode
    {
        // Внешний ключ модели "Группа"
        [Display(Name = "Группа")]
        [Required(ErrorMessage = "Укажите группу.")]
        public int GroupId { get; set; }
        [ForeignKey(nameof(GroupId))]
        [Display(Name = "Группа")]
        public GroupModel? GroupModel { get; set; }

        List<FocusModel> Focuss { get; set; }
    }
}