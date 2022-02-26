using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LariFit.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

        [Required]
        [Display(Name = "Имя пользователя")]
        [StringLength(maximumLength: 15, MinimumLength = 2, ErrorMessage = "Длина имени пользователя - от 2 до 15")]
        public string UserName { get; set; }
    }
}
