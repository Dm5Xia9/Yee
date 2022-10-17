using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Yee.CoreLayout.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле логин обязательно")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле пароль обязательно")]
        [StringLength(100, ErrorMessage = "Поле пароль должно содержать от {2} до {1} символов", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле подтвердить пароль обязательно")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public string IpAdress { get; set; }

    }
}
