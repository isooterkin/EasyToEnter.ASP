using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Адрес")]
    [Index(nameof(CityId), nameof(Street), nameof(House), nameof(Housing), nameof(Building), nameof(Latitude), nameof(Longitude), IsUnique = true)]
    public class AddressModel : ModelWithId
    {
        [Display(Name = "Город")]
        [Required(ErrorMessage = "Укажите город.")]
        [JsonPropertyName("CityId")]
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        [Display(Name = "Город")]
        [JsonPropertyName("CityModel")]
        public CityModel? CityModel { get; set; }



        [Required(ErrorMessage = "Укажите улицу.")]
        [Display(Name = "Улица")]
        [JsonPropertyName("Street")]
        public string Street { get; set; }



        [Required(ErrorMessage = "Укажите дом.")]
        [Display(Name = "Дом")]
        [JsonPropertyName("House")]
        public string House { get; set; }



        [Display(Name = "Корпус")]
        [JsonPropertyName("Housing")]
        public string? Housing { get; set; }



        [Display(Name = "Строение")]
        [JsonPropertyName("Building")]
        public string? Building { get; set; }



        [Required(ErrorMessage = "Укажите широту.")]
        [Display(Name = "Широта")]
        [Range(typeof(float), "-90.0", "90.0", ErrorMessage = "Диапазон широты от -90,0 до 90,00")]
        [DisplayFormat(DataFormatString = @"{0:0.00}", ApplyFormatInEditMode = true)]
        [JsonPropertyName("Latitude")]
        public float Latitude { get; set; }



        [Required(ErrorMessage = "Укажите долготу.")]
        [Display(Name = "Долгота")]
        [Range(typeof(float), "-90.0", "90.0", ErrorMessage = "Диапазон долготы от -180,0 до 180,00")]
        [DisplayFormat(DataFormatString = @"{0:0.00}", ApplyFormatInEditMode = true)]
        [JsonPropertyName("Longitude")]
        public float Longitude { get; set; }



        [NotMapped]
        [Display(Name = "Полный адрес")]
        [JsonPropertyName("FullAddress")]
        public string FullAddress 
        {
            get
            {
                string result = $"Россия, {CityModel?.RegionModel?.Name}, {CityModel?.Name}, ул. {Street}, д. {House}";
                if (Housing != null) result += $", к. {Housing}";
                if (Building != null) result += $", лит. {Building}";
                return result;
            }
        }



        [Display(Name = "ВУЗы выбранного адреса")]
        [JsonPropertyName("Universitys")]
        public List<UniversityModel>? Universitys { get; set; }



        [Display(Name = "Общежития выбранного адреса")]
        [JsonPropertyName("Dormitorys")]
        public List<DormitoryModel>? Dormitorys { get; set; }
    }
}