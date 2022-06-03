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
        [JsonPropertyName(nameof(Login))]
        public string Login { get; set; }



        [Required(ErrorMessage = "Укажите пароль.")]
        [Display(Name = "Пароль")]
        [JsonPropertyName(nameof(Password))]
        public string Password { get; set; }
    }
}