using EasyToEnter.ASP.Models.Dependence;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Вариативность"
    [Display(Name = "Вариативность")]
    [Index(nameof(FormId), nameof(FocusUniversityId), nameof(PaymentId), nameof(FormatId), IsUnique = true)]
    public class VariabilityModel: ModelWithId
    {
        [Required(ErrorMessage = "Укажите период обучения.")]
        [Display(Name = "Период обучения")]
        [JsonPropertyName("TrainingPeriod")]
        public int TrainingPeriod { get; set; }



        [Required(ErrorMessage = "Укажите наличие вступительных экзаменов.")]
        [Display(Name = "Вступительные экзамены")]
        [JsonPropertyName("EntranceExams")]
        public bool EntranceExams { get; set; } = false;



        [Display(Name = "Форма")]
        [Required(ErrorMessage = "Укажите форму.")]
        [JsonPropertyName("FormId")]
        public int FormId { get; set; }
        [ForeignKey(nameof(FormId))]
        [Display(Name = "Форма")]
        [JsonPropertyName("FormModel")]
        public FormModel? FormModel { get; set; }



        [Display(Name = "Оплата")]
        [Required(ErrorMessage = "Укажите оплату.")]
        [JsonPropertyName("PaymentId")]
        public int PaymentId { get; set; }
        [ForeignKey(nameof(PaymentId))]
        [Display(Name = "Оплата")]
        [JsonPropertyName("PaymentModel")]
        public PaymentModel? PaymentModel { get; set; }



        [Display(Name = "Формат")]
        [Required(ErrorMessage = "Укажите формат.")]
        [JsonPropertyName("FormatId")]
        public int FormatId { get; set; }
        [ForeignKey(nameof(FormatId))]
        [Display(Name = "Формат")]
        [JsonPropertyName("FormatModel")]
        public FormatModel? FormatModel { get; set; }



        [Display(Name = "Направленность ВУЗа")]
        [Required(ErrorMessage = "Укажите направленность ВУЗа.")]
        [JsonPropertyName("FocusUniversityId")]
        public int FocusUniversityId { get; set; }
        [ForeignKey(nameof(FocusUniversityId))]
        [Display(Name = "Направленность ВУЗа")]
        [JsonPropertyName("FocusUniversityModel")]
        public FocusUniversityModel? FocusUniversityModel { get; set; }



        [Display(Name = "Истории вариативности выбранной вариативности")]
        [JsonPropertyName("HistoryVariabilitys")]
        public List<HistoryVariabilityModel>? HistoryVariabilitys { get; set; }



        [NotMapped]
        [Display(Name = "История за текущий год")]
        [JsonPropertyName("YearHistoryVariability")]
        public HistoryVariabilityModel? YearHistoryVariability => HistoryVariabilitys?.Any() == true ? HistoryVariabilitys.OrderBy(x => x.Year).Last() : null;
    }
}