using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Уровень - Направленность")]
    [Index(nameof(LevelId), nameof(FocusId), IsUnique = true)]
    public class LevelFocusModel : ModelWithId
    {
        [Display(Name = "Уровень")]
        [Required(ErrorMessage = "Укажите уровень.")]
        [JsonPropertyName("LevelId")]
        public int LevelId { get; set; }
        [ForeignKey(nameof(LevelId))]
        [Display(Name = "Уровень")]
        [JsonPropertyName("LevelModel")]
        public LevelModel? LevelModel { get; set; }



        [Display(Name = "Направленность")]
        [Required(ErrorMessage = "Укажите направленность.")]
        [JsonPropertyName("FocusId")]
        public int FocusId { get; set; }
        [ForeignKey(nameof(FocusId))]
        [Display(Name = "Направленность")]
        [JsonPropertyName("FocusModel")]
        public FocusModel? FocusModel { get; set; }



        [NotMapped]
        [Display(Name = "Код")]
        [JsonPropertyName("FullCode")]
        public string FullCode => $"{FocusModel?.DirectionModel?.GroupModel?.Code}.{LevelModel?.Code}.{FocusModel?.DirectionModel?.Code}";
        


        [NotMapped]
        [Display(Name = "Наименование")]
        [JsonPropertyName("FullCodeName")]
        public string FullCodeName => $"{FullCode} {FocusModel?.DirectionModel?.Name}";



        [NotMapped]
        [Display(Name = "Наименование")]
        [JsonPropertyName("CodeName")]
        public string CodeName => $"{FullCode} {FocusModel?.Name}";



        [NotMapped]
        [Display(Name = "Наименование группы")]
        [JsonPropertyName("GroupFullName")]
        public string GroupFullName => $"{FocusModel?.DirectionModel?.GroupModel?.Code}.{LevelModel?.Code}.00 {FocusModel?.DirectionModel?.GroupModel?.Name}";



        [NotMapped]
        [Display(Name = "Наименование направления")]
        [JsonPropertyName("DirectionFullName")]
        public string DirectionFullName => $"{FocusModel?.DirectionModel?.GroupModel?.Code}.{LevelModel?.Code}.{FocusModel?.DirectionModel?.Code} {FocusModel?.DirectionModel?.Name}";



        [NotMapped]
        [Display(Name = "Наименование направленности")]
        [JsonPropertyName("FocusFullName")]
        public string FocusFullName => $"{FocusModel?.DirectionModel?.GroupModel?.Code}.{LevelModel?.Code}.{FocusModel?.DirectionModel?.Code} {FocusModel?.Name}";
    }
}