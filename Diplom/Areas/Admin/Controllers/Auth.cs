using Diplom.Areas.Admin.Models.ViewModels;
using Diplom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
		public async Task<IActionResult> Index([FromServices] IConfiguration configuration)
        {
			var adminEmail = configuration.GetValue<string>("AdminCredentials:Username"); ;
			var adminPassword = configuration.GetValue<string>("AdminCredentials:Password"); ;

			var userManager = HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
			var roleManager = HttpContext.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();

			if (await roleManager.RoleExistsAsync("Administrator"))
			{
				var adminUser = await userManager.FindByEmailAsync(adminEmail);
				if (adminUser == null)
				{
					adminUser = new User { UserName = adminEmail, Email = adminEmail };
					await userManager.CreateAsync(adminUser, adminPassword);
				}

				if (!await userManager.IsInRoleAsync(adminUser, "Administrator"))
				{
					await userManager.AddToRoleAsync(adminUser, "Administrator");
				}
			}
			else
			{
				var adminRole = new IdentityRole("Administrator");
				await roleManager.CreateAsync(adminRole);

				var adminUser = new User { UserName = adminEmail, Email = adminEmail };
				await userManager.CreateAsync(adminUser, adminPassword);

				await userManager.AddToRoleAsync(adminUser, "Administrator");
			}
			return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromServices]IConfiguration configuration, [FromServices] SignInManager<User> _signInManager, [FromServices] UserManager<User> _userManager,AuthVm authVm)
        {
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(authVm.Login);
				if (user != null && await _userManager.CheckPasswordAsync(user, authVm.Password))
				{
					var isAdmin = await _userManager.IsInRoleAsync(user, "Administrator");
					if (isAdmin)
					{
						await _signInManager.SignInAsync(user, isPersistent: true);
						return RedirectToAction("Index", "AdminPanel");
					}
				}
				else
				{
					ViewBag.Error = "Неправильный логин и/или пароль";
					return View();
				}
			}
			return View();
		}
    }
}
