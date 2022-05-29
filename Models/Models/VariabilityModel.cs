using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Вариативность"
    [Display(Name = "Вариативность")]
    [Index(nameof(FormId), nameof(FocusUniversityId), nameof(PaymentId), nameof(FormatId), IsUnique = true)]
    public class VariabilityModel: ModelWithId
    {
        [Required(ErrorMessage = "Укажите наличие вступительных экзаменов.")]
        [Display(Name = "Вступительные экзамены")]
        public bool EntranceExams { get; set; } = false;

        // Внешний ключ модели "Форма"
        [Display(Name = "Форма")]
        [Required(ErrorMessage = "Укажите форму.")]
        public int FormId { get; set; }
        [ForeignKey(nameof(FormId))]
        [Display(Name = "Форма")]
        public FormModel? FormModel { get; set; }

        // Внешний ключ модели "Оплата"
        [Display(Name = "Оплата")]
        [Required(ErrorMessage = "Укажите оплату.")]
        public int PaymentId { get; set; }
        [ForeignKey(nameof(PaymentId))]
        [Display(Name = "Оплата")]
        public PaymentModel? PaymentModel { get; set; }

        // Внешний ключ модели "Формат"
        [Display(Name = "Формат")]
        [Required(ErrorMessage = "Укажите формат.")]
        public int FormatId { get; set; }
        [ForeignKey(nameof(FormatId))]
        [Display(Name = "Формат")]
        public FormatModel? FormatModel { get; set; }

        // Внешний ключ модели "Направленность ВУЗа"
        [Display(Name = "Направленность ВУЗа")]
        [Required(ErrorMessage = "Укажите направленность ВУЗа.")]
        public int FocusUniversityId { get; set; }
        [ForeignKey(nameof(FocusUniversityId))]
        [Display(Name = "Направленность ВУЗа")]
        public FocusUniversityModel? FocusUniversityModel { get; set; }

        // Лист моделей "История вариативности", принадлежащих модели "Вариативность"
        [Display(Name = "Истории вариативности выбранной вариативности")]
        public List<HistoryVariabilityModel>? HistoryVariabilitys { get; set; }

        [NotMapped]
        [Display(Name = "История за текущий год")]
        public HistoryVariabilityModel? YearHistoryVariability => HistoryVariabilitys?.Any() == true ? HistoryVariabilitys.OrderBy(x => x.Year).Last() : null;
    }
}