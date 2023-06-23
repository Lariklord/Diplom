using System.ComponentModel.DataAnnotations;

namespace Diplom.Areas.Admin.Models.ViewModels
{
    public class AuthVm
    {
        [Display(Name ="Логин")]
        [Required(ErrorMessage ="Поле Логин обязательное!")]
        public string Login { get; set; }


        [Display(Name ="Пароль")]
		[Required(ErrorMessage = "Поле Пароль обязательное!")]
		[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
