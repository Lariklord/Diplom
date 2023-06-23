using Diplom.Areas.Store.Models.ViewModels;
using Diplom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;

namespace Diplom.Areas.Store.Controllers
{
    
    [Area("Store")]
	[Authorize]
	public class ShopcartController : Controller
    {
        public async Task<IActionResult> Order([FromServices] ApplicationDbContext db)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            if (user is null)
                return NotFound();
            var curCart = await db.ShopCarts.Include(y => y.User).FirstOrDefaultAsync(x => x.Status!.Equals("current") && x.User == user);
            if (curCart is null)
            {
                curCart = new Shopcart { Status = "current", User = user! };
                await db.ShopCarts.AddAsync(curCart);
                await db.SaveChangesAsync();
            }
            var products = await db.AddedProducts.Include(x => x.Product).Where(x => x.ShopCartId == curCart!.Id).ToListAsync();
            var allProducts = products.Select(x => x.Product).ToList();
            var group = allProducts.GroupBy(x => x!.Id).ToList();

            var dict = group.ToDictionary(x => db.Products.FirstOrDefault(y => y.Id == x.Key)!, x => x.Count());
            var sum = dict.Sum(x => x.Key.Weight == 0 ? Math.Round(x.Key.Price, 2) * x.Value : Math.Round((decimal)x.Key.Weight * x.Key.Price, 2) * x.Value);

            ShopCartVM vM = new ShopCartVM { Products = dict, User = user, Phone = user.PhoneNumber, Price = sum };
            return View(vM);
        }
        public async Task<IActionResult> CreateOrder([FromServices] ApplicationDbContext db, [FromServices] IEmailSender sender, ShopCartVM vM, [FromForm] string? itemDate)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            if (user is null)
                return NotFound();
            var curCart = await db.ShopCarts.Include(y => y.User).FirstOrDefaultAsync(x => x.Status!.Equals("current") && x.User == user);
            var products = await db.AddedProducts.Include(x => x.Product).Where(x => x.ShopCartId == curCart!.Id).ToListAsync();
            var allProducts = products.Select(x => x.Product).ToList();
            var group = allProducts.GroupBy(x => x!.Id).ToList();
            var dict = group.ToDictionary(x => db.Products.FirstOrDefault(y => y.Id == x.Key)!, x => x.Count());
            var sum = dict.Sum(x => x.Key.Weight == 0 ? Math.Round(x.Key.Price, 2) * x.Value : Math.Round((decimal)x.Key.Weight * x.Key.Price, 2) * x.Value);
            vM.Price = sum;
            vM.Products = dict;
            vM.User = user;
            vM.Price = sum;
            if (ModelState.IsValid)
            {
                Order order = new Order();
                order.PaymentMethod = vM.Payment;
                order.Comment = vM.Comment;
                order.Street = vM.Street;
                order.Flour = vM.Flour;
                order.Flat = vM.Flat;
                order.Entrance = vM.Entrance;
                order.House = vM.House;
                order.OrderDate = DateTime.Now;
                order.Phone = vM.Phone;
                order.Status = "Ожидает подтверждения";
                if (vM.Type == "choose")
                {
                    order.DeliveryDate = DateTime.Parse(itemDate!);
                }
                else
                {
                    var date = DateTime.Now;
                    date = date.AddHours(1);
                    while (date.Minute % 10 != 0)
                        date = date.AddMinutes(1);
                    date = date.AddMinutes(10);
                    for (int i = 0; i < 300; i++)
                    {
                        if (date.Hour < 7)
                        {
                            i--;
                        }
                        else
                        {
                            order.DeliveryDate = date;
                            break;
                        }
                        date = date.AddMinutes(10);
                    }
                }

                order.Price = (decimal)vM.Price + 9 - (decimal)vM.Points / 100;
                order.SpentPoints = vM.Points;
                order.AccruedPoints = (int)sum * 3;
                order.ShopCartId = curCart!.Id;

                curCart.Status = "close";
                order.User = user;
                user.Points = user.Points - vM.Points;

                db.Orders.Add(order);
                db.Add(new Notification { Date = DateTime.Now, Text = $"Ваш заказ принят! В скором времени с вами свяжутся по указаному телефону для подтверждения заказа.", User = user });
                db.SaveChanges();

                await sender.SendEmailAsync(user.Email, "Ваш заказ принят!", $"В скором времени с вами свяжутся по указаному телефону для подтверждения заказа.");
                return RedirectToAction("Main", "Profile");
            }          
            return View("Order", vM);

        }
        public async Task<IActionResult> AddProduct([FromServices] ApplicationDbContext db, int productId)
        {
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            if (user is null)
                return NotFound();
            var curCart = await db.ShopCarts.Include(y => y.User).FirstOrDefaultAsync(x => x.Status!.Equals("current") && x.User == user);
            if (curCart is null)
            {
                curCart = new Shopcart { Status = "current", User = user! };
                await db.ShopCarts.AddAsync(curCart);
                await db.SaveChangesAsync();
            }
            await db.AddedProducts.AddAsync(new AddedProduct { ShopCartId = curCart.Id, ProductId = product!.Id });
            await db.SaveChangesAsync();



            var products = await db.AddedProducts.Include(x => x.Product).Where(x => x.ShopCartId == curCart!.Id).ToListAsync();
            var allProducts = products.Select(x => x.Product).ToList();
            var group = allProducts.GroupBy(x => x!.Id).ToList();

            var dict = group.ToDictionary(x => db.Products.FirstOrDefault(y => y.Id == x.Key)!, x => x.Count());
            var sum = dict.Sum(x => x.Key.Weight == 0 ? Math.Round(x.Key.Price, 2) * x.Value : Math.Round((decimal)x.Key.Weight * x.Key.Price, 2) * x.Value);

            ShopCartVM vM = new ShopCartVM { Products = dict, User = user, Phone = user.PhoneNumber, Price = sum };
            return View("Order", vM);
        }
        public async Task<IActionResult> DeleteProduct([FromServices] ApplicationDbContext db, int productId, int count = 0)
        {
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            if (user is null)
                return NotFound();
            var curCart = await db.ShopCarts.Include(y => y.User).FirstOrDefaultAsync(x => x.Status!.Equals("current") && x.User == user);
            if (curCart != null)
            {
                if (count == 1)
                {
                    var addedProduct = await db.AddedProducts.FirstOrDefaultAsync(x => x.ProductId == product!.Id && x.ShopCartId == curCart.Id);
                    if (addedProduct != null)
                    {
                        db.AddedProducts.Remove(addedProduct);
                        await db.SaveChangesAsync();
                    }
                }
                else
                {
                    var prod = await db.AddedProducts.Where(x => x.ProductId == product!.Id && x.ShopCartId == curCart.Id).ToListAsync();
                    db.AddedProducts.RemoveRange(prod);
                    await db.SaveChangesAsync();
                }

            }
            var products = await db.AddedProducts.Include(x => x.Product).Where(x => x.ShopCartId == curCart!.Id).ToListAsync();
            var allProducts = products.Select(x => x.Product).ToList();
            var group = allProducts.GroupBy(x => x!.Id).ToList();
            var dict = group.ToDictionary(x => db.Products.FirstOrDefault(y => y.Id == x.Key)!, x => x.Count());
            var sum = dict.Sum(x => x.Key.Weight == 0 ? Math.Round(x.Key.Price, 2) * x.Value : Math.Round((decimal)x.Key.Weight * x.Key.Price, 2) * x.Value);

            ShopCartVM vM = new ShopCartVM { Products = dict, User = user, Phone = user.PhoneNumber, Price = sum };
            return View("Order", vM);
        }
    }
}
