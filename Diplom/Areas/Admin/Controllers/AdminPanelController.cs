using Diplom.Areas.Admin.Models.ViewModels;
using Diplom.Areas.Store.Models.ViewModels;
using Diplom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace Diplom.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Administrator")]
	public class AdminPanelController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}


		public async Task<IActionResult> Users([FromServices] ApplicationDbContext db)
		{
			var users = await db.Users.ToListAsync();
			return View(new UsersPanelVm { Users = users });
		}

		[HttpPost]
		public async Task<IActionResult> GetUsersBy([FromServices] ApplicationDbContext db, [FromForm] string findOption, [FromForm] string findValue)
		{
			List<User> users = new List<User>();
			if (findValue != null)
			{
				if (findOption == "mail")
				{
					users = await db.Users.Where(x => x.Email == findValue).ToListAsync();
				}
				else
				{
					users = await db.Users.Where(x => x.PhoneNumber == findValue).ToListAsync();
				}
			}
			return View("Users", new UsersPanelVm{ Users=users });
		}

		[HttpPost]
		public async Task<IActionResult> SortUsersBy([FromServices] ApplicationDbContext db, [FromForm] string sortOption, [FromForm] string sortOrder)
		{
			var users = await db.Users.ToListAsync();
			switch (sortOption)
			{
				case "surname":
					users = sortOrder == "desc" ? users.OrderByDescending(p => p.UserSurname).ToList() : users.OrderBy(p => p.UserSurname).ToList();
					break;
				case "mail":
					users = sortOrder == "desc" ? users.OrderByDescending(p => p.Email).ToList() : users.OrderBy(p => p.Email).ToList();
					break;
				default:
					users = users.OrderBy(p => p.Id).ToList();
					break;
			}

			return View("Users", new UsersPanelVm { Users = users });
		}





		public async Task<IActionResult> Orders([FromServices] ApplicationDbContext db, string? userId)
		{
			List<Order> orders = new List<Order>();
			if(userId!=null && userId!="")
			{
				orders = await db.Orders.Include(x => x.User).Where(x=>x.User.Id==userId).ToListAsync();
			}
			else
				orders = await db.Orders.Include(x => x.User).ToListAsync();

			return View(new OrdersPanelVM { Orders=orders});
        }
		[HttpPost]
		public async Task<IActionResult> GetOrdersBy([FromServices] ApplicationDbContext db, [FromForm] string findOption, [FromForm] string findValue)
		{
			List<Order> orders = new List<Order>();
			if (findValue != null)
			{
				if (findOption == "mail")
				{
					orders = await db.Orders.Include(x=>x.User).Where(x => x.User.Email == findValue).ToListAsync();
				}
				else
				{
					orders = await db.Orders.Include(x => x.User).Where(x => x.Phone == findValue).ToListAsync();
				}
			}
			return View("Orders", new OrdersPanelVM { Orders=orders });
		}

		[HttpPost]
		public async Task<IActionResult> SortOrdersBy([FromServices] ApplicationDbContext db, [FromForm] string sortOption, [FromForm] string sortOrder)
		{
			var orders = await db.Orders.Include(x => x.User).ToListAsync();
			switch (sortOption)
			{
				case "orderDate":
					orders = sortOrder == "desc" ? orders.OrderByDescending(p => p.OrderDate).ToList() : orders.OrderBy(p => p.OrderDate).ToList();
					break;
				case "fio":
					orders = sortOrder == "desc" ? orders.OrderByDescending(p => p.User.UserSurname).ThenByDescending(x=>x.User.FName).ToList() : orders.OrderBy(p => p.User.UserSurname).ThenBy(x=>x.User.FName).ToList();
					break;				
				default:
					orders = orders.OrderBy(p => p.Id).ToList();
					break;
			}

			return View("Orders", new OrdersPanelVM { Orders=orders });
		}

		[HttpPost]
		public async Task<IActionResult> FilterOrdersByStatus([FromServices] ApplicationDbContext db, [FromForm] string? status)
		{
			var orders = await db.Orders.Include(x=>x.User).ToListAsync();
			if (status!= null && !status.Equals(""))
			{
				switch (status)
				{
					case "wait":
						orders = orders.Where(x=>x.Status=="Ожидает подтверждения").ToList();
						break;
					case "complete":
						orders = orders.Where(x => x.Status == "Подтвержден").ToList();
						break;
					case "cancel":
						orders = orders.Where(x => x.Status == "Отменен").ToList();
						break;
					default:
						break;

				}
			}
			return View("Orders", new OrdersPanelVM { Orders=orders });
		}


		public async Task<IActionResult> OrderDetail([FromServices] ApplicationDbContext db, int orderId)
		{
			var order = await db.Orders.Include(x=>x.User).FirstOrDefaultAsync(x=>x.Id == orderId);
			if (order is null)
				return NotFound();
			var user = order.User;
			var cart = await db.ShopCarts.Include(y => y.User).FirstOrDefaultAsync(x => x.Id == order.ShopCartId);
			var products = await db.AddedProducts.Include(x => x.Product).Include(x=>x.Product!.Category).Where(x => x.ShopCartId == cart!.Id).ToListAsync();
			var allProducts = products.Select(x => x.Product).ToList();
			var group = allProducts.GroupBy(x => x!.Id).ToList();
			var dict = group.ToDictionary(x => db.Products.FirstOrDefault(y => y.Id == x.Key)!, x => x.Count());
			decimal total = 0;
			foreach (var item in dict)
			{
				total += item.Key.Weight == 0 ? @Math.Round(item.Key.Price, 2) * item.Value : Math.Round((decimal)item.Key!.Weight * item.Key.Price, 2) * item.Value;
			}
			OrderDetailVM vM = new OrderDetailVM { Order = order, Products = dict, User = user, Total = total };
			return View(vM);
		}

		public async Task<IActionResult> AcceptOrder([FromServices] ApplicationDbContext db, [FromServices] IEmailSender sender, int orderId)
		{
			var order = await db.Orders.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == orderId);
			if (order is null)
				return NotFound();
			order.Status = "Подтвержден";
			order.User.Points += order.AccruedPoints;

			db.Add(new Notification { Date = DateTime.Now, Text = $"Заказ №{order.Id} принят! На ваш баланс зачислено {order.AccruedPoints} баллов.\nЗаказ будет доставлен по указаному адресу {order.DeliveryDate.ToString("dd MMM HH:mm yyyy")}", User = order.User });

			await sender.SendEmailAsync(order.User.Email, $"Заказ №{order.Id} принят!", $"На ваш баланс зачислено {order.AccruedPoints} баллов.\nЗаказ будет доставлен по указаному адресу {order.DeliveryDate.ToString("dd MMM HH:mm yyyy")}");
			await db.SaveChangesAsync();
			return RedirectToAction("Orders");

		}
		public async Task<IActionResult> CancelOrder([FromServices] ApplicationDbContext db, [FromServices] IEmailSender sender, int orderId)
		{
			var order = await db.Orders.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == orderId);
			if (order is null)
				return NotFound();
			order.Status = "Отменен";
			order.User.Points +=order.SpentPoints;
			db.Add(new Notification { Date = DateTime.Now, Text = $"Заказ №{order.Id} отменен! На ваш баланс возвращено {order.SpentPoints} баллов.", User = order.User });

			await sender.SendEmailAsync(order.User.Email, $"Заказ №{order.Id} отменен!", $"На ваш баланс возвращено {order.SpentPoints} баллов.");
			await db.SaveChangesAsync();

			return RedirectToAction("Orders");

		}







		[HttpGet]
		public async Task<IActionResult> Products([FromServices] ApplicationDbContext db)
		{
			var products = await db.Products.Include(x=>x.Category).ToListAsync();
			var categorys = await db.Categories.Skip(1).ToListAsync();
            return View(new ProductsPanelVm { Products=products,Categories=categorys});
        }

		[HttpPost]
		public async Task<IActionResult> GetProductsBy([FromServices] ApplicationDbContext db, [FromForm] string findOption, [FromForm] string findValue)
		{
			List<Product> products = new List<Product>();
			if (findValue != null)
			{			
				if (findOption == "code")
				{
					if (int.TryParse(findValue, out var code))
					{
						products = await db.Products.Include(x => x.Category).Where(x => x.Code == code).ToListAsync();
					}
					else
					{
						ViewBag.FindError = "Неверный формат!";
					}

				}
				else
				{
					products = await db.Products.Include(x => x.Category).Where(x => x.Name!.Contains(findValue)).ToListAsync();
				}				
			}
			var categorys = await db.Categories.Skip(1).ToListAsync();
			return View("Products",new ProductsPanelVm { Products = products, Categories = categorys });
		}

		[HttpPost]
		public async Task<IActionResult> SortProductsBy([FromServices] ApplicationDbContext db, [FromForm]string sortOption, [FromForm] string sortOrder)
		{
			var products = await db.Products.Include(x=>x.Category).ToListAsync();
			var categorys = await db.Categories.Skip(1).ToListAsync();
			switch (sortOption)
			{
				case "code":
					products = sortOrder == "desc" ? products.OrderByDescending(p => p.Code).ToList() : products.OrderBy(p => p.Code).ToList();
					break;
				case "name":
					products = sortOrder == "desc" ? products.OrderByDescending(p => p.Name).ToList() : products.OrderBy(p => p.Name).ToList();
					break;
				case "price":
					products = sortOrder == "desc" ? products.OrderByDescending(p => p.Price).ToList() : products.OrderBy(p => p.Price).ToList();
					break;
				default:
					products = products.OrderBy(p => p.Id).ToList();
					break;
			}

			return View("Products", new ProductsPanelVm { Products = products, Categories = categorys });
		}

		[HttpPost]
		public async Task<IActionResult> FilterProductsByCategory([FromServices] ApplicationDbContext db, [FromForm]int? categoryId)
		{
			var products = await db.Products.ToListAsync();
			if (categoryId.HasValue && categoryId != 0)
			{
				products = products.Where(p => p.CategoryId == categoryId).ToList();
			}
			var categorys = await db.Categories.Skip(1).ToListAsync();
			return View("Products", new ProductsPanelVm { Products = products, Categories = categorys });
		}

		public async Task<IActionResult> ChangeProduct([FromServices] ApplicationDbContext db, int productId)
		{
			var categories = await db.Categories.Skip(1).ToListAsync();
			var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);
			if (product == null)
				return NotFound();
			return View("ProductForm", new ProductFormVM { Categories = categories, CategoryId = product.CategoryId, Code = product.Code, Composition = product.Composition, Description = product.Description, Id = product.Id, MainUrl = product.MainUrl, Name = product.Name, Price = product.Price, ShelfLife = product.ShelfLife, Weight = product.Weight });
		}
		public async Task<IActionResult> DeleteProduct([FromServices] ApplicationDbContext db, int productId)
		{
			var categories = await db.Categories.Skip(1).ToListAsync();
			var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);
			if (product == null)
				return NotFound();
			db.Products.Remove(product);
			await db.SaveChangesAsync();
			return RedirectToAction("Products");
		}

		[HttpGet]
		public async Task<IActionResult> ProductForm([FromServices] ApplicationDbContext db)
		{
			var categories = await db.Categories.Skip(1).ToListAsync();
			return View(new ProductFormVM { Categories = categories });
		}

        [HttpPost]
        public async Task<IActionResult> ProductForm([FromServices] ApplicationDbContext db, ProductFormVM vM)
        {
            vM.Categories = await db.Categories.Skip(1).ToListAsync();
            if (ModelState.IsValid)
            {
				var cat = await db.Categories.FirstOrDefaultAsync(x => x.Id == vM.CategoryId);
				if (vM.Id== 0) {
					
					var product = new Product {Code=vM.Code,Composition=vM.Composition,CategoryId=vM.CategoryId,Category=cat,Description=vM.Description,MainUrl=vM.MainUrl,Name=vM.Name,Price=vM.Price,ShelfLife=vM.ShelfLife,Weight=vM.Weight};
					await db.Products.AddAsync(product);					
				}
				else
				{
					var product = await db.Products.FirstOrDefaultAsync(x => x.Id == vM.Id);
					if (product == null)
						return NotFound();
					product.ShelfLife = vM.ShelfLife;
					product.Weight = vM.Weight;
					product.Description = vM.Description;
					product.Category = cat;
					product.Price = vM.Price;
					product.Code = vM.Code;
					product.Composition= vM.Composition;
					product.Name = vM.Name;
					product.MainUrl = vM.MainUrl;
					
				}
				await db.SaveChangesAsync();
				return RedirectToAction("Products");
            }			
            return View(vM);
        }
    }
}
