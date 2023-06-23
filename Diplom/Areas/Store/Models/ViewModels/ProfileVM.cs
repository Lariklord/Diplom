using Diplom.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Diplom.Areas.Store.Models.ViewModels
{
    public class ProfileVM
    {
        public User? User { get; set; }
        public List<Notification>? Notifications { get; set; }
        public List<Order>? Orders { get; set; }

        [Display(Name = "Телефон")]
        [RegularExpression(pattern: @"^(8025|8029|8033|8044|\+375(24|25|29|33|44))\d{3}\d{2}\d{2}$", ErrorMessage = "Неверный формат данных!")]
        public string? Phone { get; set; }

        [Display(Name = "Имя")]
        [MaxLength(20,ErrorMessage ="Максимальная длина 20 символов!")]
        public string? Name { get; set; }

        [MaxLength(20, ErrorMessage = "Максимальная длина 20 символов!")]

        [Display(Name = "Фамилия")]
        public string? Surname { get; set; }

        [Display(Name ="Дата рождения")]
        public DateTime? Birthday { get; set; }
    }
}
