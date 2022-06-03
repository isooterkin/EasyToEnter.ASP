﻿using EasyToEnter.ASP.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace EasyToEnter.ASP.ViewsModels.Authentication
{
    [Display(Name = "Форма регистрации")]
    public class SingUpViewModel: PersonModel
    {
        [Required(ErrorMessage = "Укажите пароль.")]
        [Display(Name = "Пароль")]
        [JsonPropertyName(nameof(Password))]
        public string Password { get; set; }



        [Required(ErrorMessage = "Укажите пароль.")]
        [Display(Name = "Пароль")]
        [JsonPropertyName(nameof(PasswordRepeat))]
        public string PasswordRepeat { get; set; }



        public new int? Id { get; set; }
        public new int? PasswordHash { get; set; }
    }
}