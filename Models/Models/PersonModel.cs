using EasyToEnter.ASP.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Пользователь")]
    public class PersonModel: ModelWithId
    {
        [Required(ErrorMessage = "Укажите фамилию.")]
        [Display(Name = "Фамилия")]
        [JsonPropertyName(nameof(LastName))]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Укажите имя.")]
        [Display(Name = "Имя")]
        [JsonPropertyName(nameof(FirstName))]
        public string FirstName  { get; set; }



        [Required(ErrorMessage = "кажите отчество.")]
        [Display(Name = "Отчество")]
        [JsonPropertyName(nameof(MiddleName))]
        public string MiddleName { get; set; }



        [Display(Name = "Дата рождения")]
        [JsonPropertyName(nameof(DateOfBirth))]
        public DateOnly? DateOfBirth { get; set; }



        [Required(ErrorMessage = "Укажите контактный телефон.")]
        [Display(Name = "Контактный телефон")]
        [Phone(ErrorMessage = "Неверный телефон.")]
        [JsonPropertyName(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }



        [Required(ErrorMessage = "Укажите электронную почту.")]
        [Display(Name = "Электронная почта")]
        [EmailAddress(ErrorMessage = "Неверная электронная почта.")]
        [JsonPropertyName(nameof(EmailAddress))]
        public string EmailAddress { get; set; }



        [Required(ErrorMessage = "Укажите логин.")]
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
    }
}