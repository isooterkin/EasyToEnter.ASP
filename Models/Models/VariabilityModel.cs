﻿using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "Вариативность"
    [Display(Name = "Вариативность")]
    [Index(nameof(FormId), nameof(FocusUniversityId), nameof(PaymentId), nameof(FormatId), IsUnique = true)]
    public class VariabilityModel: ModelWithId
    {
        [Required(ErrorMessage = "Укажите проходной балл.")]
        [Display(Name = "Проходной балл")]
        public int PassingGrade { get; set; }

        [Required(ErrorMessage = "Укажите стоимость обучения.")]
        [Display(Name = "Стоимость обучения")]
        public int Tuition { get; set; } = 0;

        [Required(ErrorMessage = "Укажите количество мест.")]
        [Display(Name = "Количество мест")]
        public int NumberSeats { get; set; }

        [Required(ErrorMessage = "Укажите период обучения.")]
        [Display(Name = "Период обучения")]
        public int PeriodStudy { get; set; }

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
    }
}