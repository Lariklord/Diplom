using System.ComponentModel.DataAnnotations;
using Diplom.Models;

namespace Diplom.Areas.Store.Models.ViewModels
{
    public class ShopCartVM
    {
        public User? User { get; set; }
        public Dictionary<Product, int>? Products { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Поле Телефон обязательное!")]
        [RegularExpression(pattern: @"^(8025|8029|8033|8044|\+375(24|25|29|33|44))\d{3}\d{2}\d{2}$", ErrorMessage = "Неверный формат данных!")]
        public string? Phone { get; set; }


        [Display(Name = "Улица")]
        [Required(ErrorMessage = "Поле Улица обязательное!")]
        public string? Street { get; set; }


        [Display(Name = "Дом")]
        [RegularExpression(pattern: @"^\d+[A-Za-z]?(\/\d+[A-Za-z]?)?$", ErrorMessage = "Неверный формат данных!")]
        [Required(ErrorMessage = "Поле Дом обязательное!")]
        public string? House { get; set; }


        [Display(Name = "Подъезд")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Неверный формат данных!")]
        public string? Entrance { get; set; }


        [Display(Name = "Этаж")]
        [RegularExpression(@"^([1-9]|[1-9][0-9]+)$", ErrorMessage = "Неверный формат данных!")]
        public string? Flour { get; set; }


        [Display(Name = "Квартира")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Неверный формат данных!")]
        public string? Flat { get; set; }


        [Display(Name = "Введите комментарий")]
        public string? Comment { get; set; }


        public string? Type { get; set; }
        public string? Payment { get; set; }

        [Display(Name = "Бонусные баллы")]
        public int Points { get; set; }

        [Display(Name = "Промокод")]
        public string? Promo { get; set; }

        public decimal? Price { get; set; }
    }
}
