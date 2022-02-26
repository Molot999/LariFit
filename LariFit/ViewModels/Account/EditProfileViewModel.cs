using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LariFit.ViewModels.Account
{
    public class EditProfileViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Имя пользователя")]
        [StringLength(maximumLength: 15, MinimumLength = 2, ErrorMessage = "Длина имени пользователя - от 2 до 15")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Для изменения данных укажите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

    }
}
