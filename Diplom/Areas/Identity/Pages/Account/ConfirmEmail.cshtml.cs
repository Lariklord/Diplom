#nullable disable
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Diplom.Areas.Identity.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        public ConfirmEmailModel(UserManager<User> userManager,[FromServices]ApplicationDbContext db)
        {
            _userManager = userManager;
            _context = db;
        }
        [TempData]
        public string StatusMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            StatusMessage = result.Succeeded ? "Спасибо за подтверждение почты." : "Ошибка подтверждения почты.";
            if (result.Succeeded)
            {
                _context.Notifications.Add(new Notification { Date = DateTime.Now, Text = "Аккаунт успешно создан. На ваш баланс начисленно 100 баллов", User = user });
                user.Points += 100;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Catalog", "Home", new { area="Store"});
        }
    }
}
