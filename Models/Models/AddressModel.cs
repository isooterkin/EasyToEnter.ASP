using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Адрес"
    [Display(Name = "Адрес")]
    [Index(nameof(CityId), nameof(Street), nameof(House), nameof(Housing), nameof(Building), nameof(Latitude), nameof(Longitude), IsUnique = true)]
    public class AddressModel : ModelWithId
    {
        // Внешний ключ модели "Город"
        [Display(Name = "Город")]
        [Required(ErrorMessage = "Укажите город.")]
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        [Display(Name = "Город")]
        public CityModel? CityModel { get; set; }

        [Required(ErrorMessage = "Укажите улицу.")]
        [Display(Name = "Улица")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Укажите дом.")]
        [Display(Name = "Дом")]
        public string House { get; set; }

        [Display(Name = "Корпус")]
        public string? Housing { get; set; }

        [Display(Name = "Строение")]
        public string? Building { get; set; }

        [Required(ErrorMessage = "Укажите широту.")]
        [Display(Name = "Широта")]
        [Range(typeof(float), "-90.0", "90.0", ErrorMessage = "Диапазон широты от -90,0 до 90,00")]
        [DisplayFormat(DataFormatString = @"{0:0.00}", ApplyFormatInEditMode = true)]
        public float Latitude { get; set; }

        [Required(ErrorMessage = "Укажите долготу.")]
        [Display(Name = "Долгота")]
        [Range(typeof(float), "-90.0", "90.0", ErrorMessage = "Диапазон долготы от -180,0 до 180,00")]
        [DisplayFormat(DataFormatString = @"{0:0.00}", ApplyFormatInEditMode = true)]
        public float Longitude { get; set; }

        [NotMapped]
        [Display(Name = "Полный адрес")]
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

        // Лист моделей "ВУЗ", принадлежащих модели "Адрес"
        [Display(Name = "ВУЗы выбранного адреса")]
        public List<UniversityModel>? Universitys { get; set; }

        // Лист моделей "Общежитие", принадлежащих модели "Адрес"
        [Display(Name = "Общежития выбранного адреса")]
        public List<DormitoryModel>? Dormitorys { get; set; }
    }
}