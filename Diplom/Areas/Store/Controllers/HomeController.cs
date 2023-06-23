
using Diplom.Areas.Store.Models.ViewModels;
using Diplom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Areas.Store.Controllers
{
    [Area("Store")]
    public class HomeController : Controller
    {
        private CatalogVM _catalogVM;
        public HomeController([FromServices] ApplicationDbContext db)
        {
            var categories = db.Categories.ToList();
            _catalogVM = new CatalogVM { Categories = categories };
        }
        [HttpGet]
        public IActionResult Catalog()
        {
            return View(_catalogVM);
        }
        public async Task<IActionResult> LogOut([FromServices] SignInManager<User> _signInManager)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Catalog");
        }
    }
}