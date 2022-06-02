using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Группа")]
    [Index(nameof(Code), IsUnique = true)]
    public class GroupModel : ModelWithIdNameDescriptionCode
    {
        [Display(Name = "Наука")]
        [Required(ErrorMessage = "Укажите науку.")]
        [JsonPropertyName("ScienceId")]
        public int ScienceId { get; set; }
        [ForeignKey(nameof(ScienceId))]
        [Display(Name = "Наука")]
        [JsonPropertyName("ScienceModel")]
        public ScienceModel? ScienceModel { get; set; }



        [Display(Name = "Направления выбранной группы")]
        [JsonPropertyName("Directions")]
        public List<DirectionModel>? Directions { get; set; }
    }
}