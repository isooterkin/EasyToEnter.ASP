using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "ВУЗ")]
    // [Index(nameof(Abbreviation) IsUnique = true)]
    // [Index(nameof(AddressId), IsUnique = true)]
    public class UniversityModel : ModelWithIdNameDescription
    {
        [Required(ErrorMessage = "Укажите aббревиатурe.")]
        [Display(Name = "Аббревиатура")]
        [JsonPropertyName("Abbreviation")]
        public string Abbreviation { get; set; } = string.Empty;



        [Required(ErrorMessage = "Укажите электронную почту.")]
        [Display(Name = "Электронная почта")]
        [EmailAddress(ErrorMessage = "Неверная электронная почта.")]
        [JsonPropertyName("EmailAddress")]
        public string EmailAddress { get; set; } = string.Empty;



        [Required(ErrorMessage = "Укажите наличие военной кафедры.")]
        [Display(Name = "Военная кафедра")]
        [JsonPropertyName("MilitaryDepartment")]
        public bool MilitaryDepartment { get; set; } = false;



        [Required(ErrorMessage = "Укажите сайт.")]
        [Display(Name = "Сайт")]
        [Url(ErrorMessage = "Неверная ссылка.")]
        [JsonPropertyName("Website")]
        public string Website { get; set; } = string.Empty;



        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Укажите адрес.")]
        [JsonPropertyName("AddressId")]
        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        [Display(Name = "Адрес")]
        [JsonPropertyName("AddressModel")]
        public AddressModel? AddressModel { get; set; }



        [Display(Name = "Аккредитация")]
        [Required(ErrorMessage = "Укажите аккредитацию.")]
        [JsonPropertyName("AccreditationId")]
        public int AccreditationId { get; set; }
        [ForeignKey(nameof(AccreditationId))]
        [Display(Name = "Аккредитация")]
        [JsonPropertyName("AccreditationModel")]
        public AccreditationModel? AccreditationModel { get; set; }



        [Display(Name = "Специальности - вуза выбранного вуза")]
        [JsonPropertyName("SpecializationUniversitys")]
        public List<SpecializationUniversityModel>? SpecializationUniversitys { get; set; }



        [Display(Name = "Общежития выбранного вуза")]
        [JsonPropertyName("Dormitorys")]
        public List<DormitoryModel>? Dormitorys { get; set; }



        [Display(Name = "Контактные телефоны выбранного вуза")]
        [JsonPropertyName("PhoneNumbers")]
        public List<PhoneNumberUniversityModel>? PhoneNumbers { get; set; }



        [Display(Name = "Избранные ВУЗы")]
        [JsonPropertyName(nameof(UniversityFavoritess))]
        public List<UniversityFavoritesModel>? UniversityFavoritess { get; set; }



        [Display(Name = "Направленности ВУЗа")]
        [JsonPropertyName(nameof(FocusUniversitys))]
        public List<FocusUniversityModel>? FocusUniversitys { get; set; }


        public int PassingGrade()
        {
            if (FocusUniversitys == null) return 0;

            if (!FocusUniversitys.Any()) return 0;

            List<VariabilityModel> variabilityList = FocusUniversitys.SelectMany(fu => fu.Variabilitys!).ToList();

            int? passingGrade = null;

            for (var j = 0; j < variabilityList.Count; j++)
            {
                HistoryVariabilityModel? yearHistoryVariability = variabilityList[j].YearHistoryVariability;

                if (yearHistoryVariability != null)
                {
                    int passingGradeHistory = yearHistoryVariability.PassingGrade;

                    if (passingGrade == null) passingGrade = passingGradeHistory;
                    else if (passingGrade > passingGradeHistory) passingGrade = passingGradeHistory;
                }
            }

            return passingGrade != null ? (int) passingGrade : 0;
        }

        public int VariabilityCount()
        {
            if (FocusUniversitys == null) return 0;

            if (!FocusUniversitys.Any()) return 0;

            return FocusUniversitys.SelectMany(fu => fu.Variabilitys!).ToList().Count;
        }

        public int NumberSeats()
        {
            if (FocusUniversitys == null) return 0;

            if (!FocusUniversitys.Any()) return 0;

            List<VariabilityModel> variabilityList = FocusUniversitys.SelectMany(fu => fu.Variabilitys!).ToList();

            int numberSeats = 0;

            for (var j = 0; j < variabilityList.Count; j++)
            {
                HistoryVariabilityModel? yearHistoryVariability = variabilityList[j].YearHistoryVariability;

                if (yearHistoryVariability != null)
                    numberSeats += yearHistoryVariability.NumberSeats;
            }

            return numberSeats;
        }

        public int MinTuition()
        {
            if (FocusUniversitys == null) return 0;

            if (!FocusUniversitys.Any()) return 0;

            List<VariabilityModel> variabilityList = FocusUniversitys
                .SelectMany(fu => fu.Variabilitys!)
                .ToList();

            int? minTuition = null;

            for (var j = 0; j < variabilityList.Count; j++)
            {
                HistoryVariabilityModel? yearHistoryVariability = variabilityList[j].YearHistoryVariability;

                if (yearHistoryVariability != null)
                    if (yearHistoryVariability.Tuition != 0)
                        if (minTuition == null) minTuition = yearHistoryVariability.Tuition;
                        else if (minTuition > yearHistoryVariability.Tuition)
                            minTuition = yearHistoryVariability.Tuition;
            }

            return minTuition != null ? (int)minTuition : 0;
        }
    }
}