using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Пользователь")]
    [Index(nameof(Login), IsUnique = true)]
    public class PersonModel: ModelWithId
    {
        [Display(Name = "Фамилия")]
        [JsonPropertyName(nameof(LastName))]
        public string? LastName { get; set; }



        [Display(Name = "Имя")]
        [JsonPropertyName(nameof(FirstName))]
        public string? FirstName  { get; set; }



        [Display(Name = "Отчество")]
        [JsonPropertyName(nameof(MiddleName))]
        public string? MiddleName { get; set; }



        [Display(Name = "Дата рождения")]
        [JsonPropertyName(nameof(DateOfBirth))]
        public DateOnly? DateOfBirth { get; set; }



        [Display(Name = "Контактный телефон")]
        [Phone(ErrorMessage = "Неверный телефон.")]
        [JsonPropertyName(nameof(PhoneNumber))]
        public string? PhoneNumber { get; set; }



        [Display(Name = "Электронная почта")]
        [EmailAddress(ErrorMessage = "Неверная электронная почта.")]
        [JsonPropertyName(nameof(EmailAddress))]
        public string? EmailAddress { get; set; }



        [Required(ErrorMessage = "Укажите логин.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Длина логина должна быть от 4 до 50 символов.")]
        [Display(Name = "Логин")]
        [JsonPropertyName(nameof(Login))]
        public string Login { get; set; }



        [Required(ErrorMessage = "Укажите пароль.")]
        [Display(Name = "Пароль")]
        [JsonPropertyName(nameof(PasswordHash))]
        public string PasswordHash { get; set; }

        

        [Display(Name = "Роль")]
        [Required(ErrorMessage = "Укажите роль.")]
        [JsonPropertyName(nameof(RoleId))]
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        [Display(Name = "Роль")]
        [JsonPropertyName(nameof(RoleModel))]
        public RoleModel? RoleModel { get; set; }



        [Display(Name = "Избранные вариативности")]
        [JsonPropertyName("VariabilityFavoritess")]
        public List<VariabilityFavoritesModel>? VariabilityFavoritess { get; set; }



        [Display(Name = "Избранные ВУЗы")]
        [JsonPropertyName("UniversityFavoritess")]
        public List<UniversityFavoritesModel>? UniversityFavoritess { get; set; }
    }
}