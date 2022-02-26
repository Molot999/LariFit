using System.ComponentModel.DataAnnotations;

namespace LariFit.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        [StringLength(maximumLength: 15, MinimumLength = 2, ErrorMessage = "Длина имени пользователя - от 2 до 15")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}
