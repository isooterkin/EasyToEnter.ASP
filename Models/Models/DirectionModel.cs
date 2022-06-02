using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Направление")]
    public class DirectionModel : ModelWithIdNameDescriptionCode
    {
        [Display(Name = "Группа")]
        [Required(ErrorMessage = "Укажите группу.")]
        [JsonPropertyName("GroupId")]
        public int GroupId { get; set; }
        [ForeignKey(nameof(GroupId))]
        [Display(Name = "Группа")]
        [JsonPropertyName("GroupModel")]
        public GroupModel? GroupModel { get; set; }



        [Display(Name = "Направленности выбранного направления")]
        [JsonPropertyName("Focuss")]
        public List<FocusModel>? Focuss { get; set; }
    }
}