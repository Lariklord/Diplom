using Diplom.Models;
using System.ComponentModel.DataAnnotations;

namespace Diplom.Areas.Admin.Models.ViewModels
{
	public class ProductFormVM
	{
		public List<Category>? Categories { get; set; }	
		public int Id { get; set; }

		[Display(Name = "Название")]
		[Required(ErrorMessage ="Поле название обязательное!")]
		public string? Name { get; set; }


		[Display(Name = "Описание")]
		[Required(ErrorMessage = "Поле описание обязательное!")]
		public string? Description { get; set; }


		[Display(Name = "Состав")]
		public string? Composition { get; set; }


		[Display(Name = "Артикул")]
		[Required(ErrorMessage = "Поле артикул обязательное!")]
		[RegularExpression(@"^\d+$",ErrorMessage ="Неверный формат данных!")]
		public int Code { get; set; }


		[Display(Name = "Срок годности")]
		public string? ShelfLife { get; set; }


		[Display(Name = "Цена (кг./р.)")]
		[Required(ErrorMessage = "Поле цена обязательное!")]
		[RegularExpression(@"^[0-9]*[.,]?[0-9]+$", ErrorMessage ="Неверный формат данных!")]
		public decimal Price { get; set; }


		[Display(Name = "Ссылка на изображение")]
		[Required(ErrorMessage ="Поле ссылка на изображение обязательное!")]
		[RegularExpression(@"\bhttps?:\/\/\S+\.(jpg|jpeg|png|gif)\b", ErrorMessage = "Неверный формат данных!")]
		public string? MainUrl { get; set; }

		[Display(Name = "Вес (кг.)")]
		[Required(ErrorMessage = "Поле вес обязательное!")]
		[RegularExpression(@"^[0-9]*[.,]?[0-9]+$", ErrorMessage = "Неверный формат данных!")]
		public double Weight { get; set; }

		[Display(Name="Категория")]
		[Required(ErrorMessage ="Поле категория обязательное!")]
		public int CategoryId { get; set; }
	}
}
