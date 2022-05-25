using System.ComponentModel.DataAnnotations;

namespace EasyToEnter.ASP.Models.Auxiliary
{
    // Модель "Локация"
    [Display(Name = "Локация")]
    public class LocationModel
    {
        public LocationModel(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public LocationModel()
        {
            Latitude = 0;
            Longitude = 0;
        }

        [Required(ErrorMessage = "Укажите широту.")]
        [Display(Name = "Широта")]
        public float Latitude { get; set; }

        [Required(ErrorMessage = "Укажите долготу.")]
        [Display(Name = "Долгота")]
        public float Longitude { get; set; }
    }
}