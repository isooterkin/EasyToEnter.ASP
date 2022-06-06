using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace EasyToEnter.ASP.ViewsModels.Authentication
{
    [Display(Name = "Форма авторизации")]
    public class SingInViewModel
    {
        [Required(ErrorMessage = "Укажите логин.")]
        [Display(Name = "Логин")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Длина логина должна быть от 4 до 50 символов.")]
        [JsonPropertyName(nameof(Login))]
        public string Login { get; set; }



        [Required(ErrorMessage = "Укажите пароль.")]
        [Display(Name = "Пароль")]
        [StringLength(int.MaxValue, MinimumLength = 8, ErrorMessage = "Длина пароля должна быть от 8 символов.")]
        [JsonPropertyName(nameof(Password))]
        public string Password { get; set; }
    }
}