using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Специальность - ВУЗ")]
    [Index(nameof(SpecializationId), nameof(UniversityId), IsUnique = true)]
    public class SpecializationUniversityModel: ModelWithId
    {
        [Display(Name = "Специальность")]
        [Required(ErrorMessage = "Укажите специальность.")]
        [JsonPropertyName("SpecializationId")]
        public int SpecializationId { get; set; }
        [ForeignKey(nameof(SpecializationId))]
        [Display(Name = "Специальность")]
        [JsonPropertyName("SpecializationModel")]
        public SpecializationModel? SpecializationModel { get; set; }



        [Display(Name = "ВУЗ")]
        [Required(ErrorMessage = "Укажите ВУЗ.")]
        [JsonPropertyName("UniversityId")]
        public int UniversityId { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [Display(Name = "ВУЗ")]
        [JsonPropertyName("UniversityModel")]
        public UniversityModel? UniversityModel { get; set; }
    }
}