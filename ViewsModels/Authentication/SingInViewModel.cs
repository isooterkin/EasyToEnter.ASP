using EasyToEnter.ASP.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace EasyToEnter.ASP.ViewsModels.Authentication
{
    [Display(Name = "Форма авторизации")]
    public class SingInViewModel: PersonModel
    {
        [Required(ErrorMessage = "Укажите пароль.")]
        [Display(Name = "Пароль")]
        [StringLength(int.MaxValue, MinimumLength = 8, ErrorMessage = "Длина пароля должна быть от 8 символов.")]
        [JsonPropertyName(nameof(Password))]
        public string Password { get; set; }



        public new int? Id { get; set; }
        public new int? PasswordHash { get; set; }
    }
}