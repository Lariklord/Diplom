using Diplom.Areas.Store.Models.ViewModels;
using Diplom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Diplom.Areas.Store.Controllers
{
    [Authorize]
    [Area("Store")]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _db;
        private ProfileVM _profileVM;
        public ProfileController(UserManager<User> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
            _profileVM = new ProfileVM();
        }
        [HttpGet]
        public async Task<IActionResult> Main()
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            if (user is null)
                return NotFound();
            var notifications = await _db.Notifications.Where(x => x.User == user).OrderByDescending(i => i.Date).ToListAsync();
            var orders = await _db.Orders.Where(x => x.User == user).OrderByDescending(x => x.OrderDate).ToListAsync();
            _profileVM.Orders = orders;
            _profileVM.User = user;
            _profileVM.Notifications = notifications;
            return View(_profileVM);
        }
        [HttpPost]
        public async Task<IActionResult> Main(ProfileVM vM)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            vM.User = user;
            var notifications = await _db.Notifications.Where(x => x.User == user).OrderByDescending(i => i.Date).ToListAsync();
            vM.Notifications = notifications;
            var orders = await _db.Orders.Where(x => x.User == user).OrderByDescending(x => x.OrderDate).ToListAsync();
            vM.Orders = orders;
            if (user is null)
                return NotFound();
            if (ModelState.IsValid)
            {
               
                user.PhoneNumber = vM.Phone ?? user.PhoneNumber;
                user.Birthday = vM.Birthday ?? user.Birthday;
                user.FName = vM.Name ?? user.FName;
                user.UserSurname = vM.Surname ?? user.UserSurname;
                await _db.SaveChangesAsync();
               
                return View(vM);
            }
            return View("Main", vM);
           
        }
        [HttpPost]
        public async Task<IActionResult> Card(string payment)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            if (user is null)
                return NotFound();
            user.PaymentMethod = payment;
            await _db.SaveChangesAsync();
            _profileVM.User = user;
            var notifications = await _db.Notifications.Where(x => x.User == user).OrderByDescending(i => i.Date).ToListAsync();
            _profileVM.Notifications = notifications;
            var orders = await _db.Orders.Where(x => x.User == user).OrderByDescending(x => x.OrderDate).ToListAsync();
            _profileVM.Orders = orders;
            return View("Main", _profileVM);
        }
        public async Task<IActionResult> OrderDetail(int orderId)

        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            if (user is null)
                return NotFound();
            var order = await _db.Orders.FirstOrDefaultAsync(x => x.User == user && x.Id == orderId);
            if (order is null)
                return NotFound();
            var cart = await _db.ShopCarts.Include(y => y.User).FirstOrDefaultAsync(x => x.Id == order.ShopCartId);
            var products = await _db.AddedProducts.Include(x => x.Product).Where(x => x.ShopCartId == cart!.Id).ToListAsync();
            var allProducts = products.Select(x => x.Product).ToList();
            var group = allProducts.GroupBy(x => x!.Id).ToList();
            var dict = group.ToDictionary(x => _db.Products.FirstOrDefault(y => y.Id == x.Key)!, x => x.Count());
            decimal total = 0;
            foreach (var item in dict)
            {
                total += item.Key.Weight == 0 ? @Math.Round(item.Key.Price, 2) * item.Value : Math.Round((decimal)item.Key!.Weight * item.Key.Price, 2) * item.Value;
            }
            OrderDetailVM vM = new OrderDetailVM { Order = order, Products = dict, User = user, Total = total };
            return View(vM);
        }
    }
}
