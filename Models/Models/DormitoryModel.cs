using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Общежитие")]
    [Index(nameof(AddressId), nameof(UniversityId), nameof(Name), IsUnique = true)]
    public class DormitoryModel: ModelWithId
    {
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Укажите адрес.")]
        [JsonPropertyName("AddressId")]
        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        [Display(Name = "Адрес")]
        [JsonPropertyName("AddressModel")]
        public AddressModel? AddressModel { get; set; }



        [Display(Name = "ВУЗ")]
        [Required(ErrorMessage = "Укажите ВУЗ.")]
        [JsonPropertyName("UniversityId")]
        public int UniversityId { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [Display(Name = "ВУЗ")]
        [JsonPropertyName("UniversityModel")]
        public UniversityModel? UniversityModel { get; set; }



        [Display(Name = "Контактный телефон")]
        [Phone(ErrorMessage = "Неверный телефон.")]
        [JsonPropertyName("PhoneNumber")]
        public string? PhoneNumber { get; set; }



        [Display(Name = "Размер платы")]
        [JsonPropertyName("Amount")]
        public int? Amount { get; set; }



        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Укажите наименование.")]
        [JsonPropertyName("Name")]
        public string Name { set; get; }
    }
}