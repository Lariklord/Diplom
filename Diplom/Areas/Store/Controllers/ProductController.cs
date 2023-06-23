using Diplom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Diplom.Areas.Store.Models.ViewModels;

namespace Diplom.Areas.Store.Controllers
{
    [Area("Store")]
    public class ProductController : Controller
    {
        ProductsVM productsVM { get; set; }
        InfoVM infoVM { get; set; }
        public ProductController([FromServices] ApplicationDbContext db)
        {
            var categories = db.Categories.ToList();
            productsVM = new ProductsVM { Categories = categories };
            infoVM = new InfoVM { Categories = categories };
        }
        [Authorize]
        public async Task<IActionResult> GetFavProducts([FromServices] ApplicationDbContext db)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            var products = await db.FavouriteProducts.Include(x => x.Product).Where(x => x.User == user).Select(x => x.Product).ToListAsync();
            if (products.Count() == 0)
                productsVM.ErrorMessage = "У вас нет избранных товаров :(";
            productsVM.Products = products!;
            return View("Index", productsVM);
        }
        public async Task<IActionResult> Index([FromServices] ApplicationDbContext db, int categoryId)
        {
            List<Product> products = new List<Product>();
            if (categoryId == 1)
            {
                var user = await db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
                if (user != null)
                {
                    var baskets = await db.ShopCarts.Include(y => y.User).Include(x => x.Products).Where(x => x.Status == "close" && x.User == user).ToListAsync();
                    foreach (var item in baskets)
                    {
                        foreach (var item1 in item.Products)
                        {
                            var product = await db.Products.FirstAsync(x => x.Id == item1.ProductId);
                            products.Add(product);
                        }
                    }
                    products = products.Distinct().ToList();
                }
            }
            else
            {
                products = await db.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
            }
            var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
            if (products.Count() == 0)
                productsVM.ErrorMessage = "В этой категории пока ничего нет :(";
            productsVM.Products = products;
            productsVM.CurrentCategory = category;
            return View(productsVM);
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromServices] ApplicationDbContext db, string productName)
        {
            var products = await db.Products.Where(x => x.Name!.ToLower().Contains(productName.ToLower())).ToListAsync();
            productsVM.Products = products;
            if (products.Count() == 0)
                productsVM.ErrorMessage = "Товары не найдены :(";

            return View(productsVM);
        }
        public async Task<IActionResult> Info([FromServices] ApplicationDbContext db, int productId)
        {
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);
            var fav = await db.FavouriteProducts.Include(y => y.User).FirstOrDefaultAsync(x => x.ProductId == productId && x.User.Email.Equals(User.Identity!.Name));
            bool isFav = fav != null;
            int count = 0;
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            var curCart = await db.ShopCarts.Include(y => y.User).FirstOrDefaultAsync(x => x.Status!.Equals("current") && x.User == user);
            if (curCart != null)
            {
                count = await db.AddedProducts.Where(x => x.ProductId == productId && x.ShopCartId == curCart.Id).CountAsync();
            }
            infoVM.AddedCount = count;
            infoVM.IsFav = isFav;
            infoVM.Product = product;
            return View(infoVM);
        }
        [Authorize]
        public async Task<IActionResult> Favourite([FromServices] ApplicationDbContext db, int productId)
        {
            bool isFav;
            int count = 0;
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            var curCart = await db.ShopCarts.Include(y => y.User).FirstOrDefaultAsync(x => x.Status!.Equals("current") && x.User == user);
            var fav = await db.FavouriteProducts.Include(y => y.User).FirstOrDefaultAsync(x => x.ProductId == productId && x.User.Email.Equals(User.Identity!.Name));
            if (fav != null)
            {
                db.FavouriteProducts.Remove(fav);
                isFav = false;
            }
            else
            {
                await db.FavouriteProducts.AddAsync(new FavouriteProduct { Product = product, User = user! });
                isFav = true;
            }
            await db.SaveChangesAsync();

            if (curCart != null)
            {
                count = await db.AddedProducts.Where(x => x.ProductId == productId && x.ShopCartId == curCart.Id).CountAsync();
            }
            infoVM.AddedCount = count;
            infoVM.IsFav = isFav;
            infoVM.Product = product;
            return View("Info", infoVM);
        }
        [HttpPost]
        public async Task<IActionResult> Sort([FromServices] ApplicationDbContext db, int categoryId, [FromForm] string sort = "default")
        {
            List<Product> products = new List<Product>();
            if (categoryId == 1)
            {
                var user = await db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
                if (user != null)
                {
                    var baskets = await db.ShopCarts.Include(y => y.User).Include(x => x.Products).Where(x => x.Status == "close" && x.User == user).ToListAsync();
                    foreach (var item in baskets)
                    {
                        foreach (var item1 in item.Products)
                        {
                            var product = await db.Products.FirstAsync(x => x.Id == item1.ProductId);
                            products.Add(product);
                        }
                    }
                    products = products.Distinct().ToList();
                }
            }
            else
            {
                products = await db.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
            }
            var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
            if (products.Count() == 0)
                productsVM.ErrorMessage = "В этой категории пока ничего нет :(";
            products = sort switch
            {
                "up" => products.OrderBy(x => x.Weight == 0 ? x.Price : x.Price * (decimal)x.Weight).ToList(),
                "down" => products.OrderByDescending(x => x.Weight == 0 ? x.Price : x.Price * (decimal)x.Weight).ToList(),
                _ => products
            };
            productsVM.Products = products;
            productsVM.CurrentCategory = category;
            return View("Index", productsVM);
        }
        [Authorize]
        public async Task<IActionResult> AddToCart([FromServices] ApplicationDbContext db, int productId)
        {
            var fav = await db.FavouriteProducts.Include(y => y.User).FirstOrDefaultAsync(x => x.ProductId == productId && x.User.Email.Equals(User.Identity!.Name));
            bool isFav = fav != null;
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            var curCart = await db.ShopCarts.Include(y => y.User).FirstOrDefaultAsync(x => x.Status!.Equals("current") && x.User == user);
            if (curCart is null)
            {
                curCart = new Shopcart { Status = "current", User = user! };
                await db.ShopCarts.AddAsync(curCart);
                await db.SaveChangesAsync();
            }
            await db.AddedProducts.AddAsync(new AddedProduct { ShopCartId = curCart.Id, ProductId = product!.Id });
            await db.SaveChangesAsync();
            int count = await db.AddedProducts.Where(x => x.ProductId == productId && x.ShopCartId == curCart.Id).CountAsync();
            infoVM.AddedCount = count;
            infoVM.IsFav = isFav;
            infoVM.Product = product;
            return View("Info", infoVM);
        }
        [Authorize]
        public async Task<IActionResult> DeleteFromCart([FromServices] ApplicationDbContext db, int productId)
        {
            var fav = await db.FavouriteProducts.Include(y => y.User).FirstOrDefaultAsync(x => x.ProductId == productId && x.User.Email.Equals(User.Identity!.Name));
            bool isFav = fav != null;
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email.Equals(User.Identity!.Name));
            var curCart = await db.ShopCarts.Include(y => y.User).FirstOrDefaultAsync(x => x.Status!.Equals("current") && x.User == user);
            if (curCart != null)
            {
                var addedProduct = await db.AddedProducts.FirstOrDefaultAsync(x => x.ProductId == product!.Id && x.ShopCartId == curCart.Id);
                if (addedProduct != null)
                {
                    db.AddedProducts.Remove(addedProduct);
                    await db.SaveChangesAsync();
                }
            }
            int count = await db.AddedProducts.Where(x => x.ProductId == productId && x.ShopCartId == curCart!.Id).CountAsync();
            infoVM.AddedCount = count;
            infoVM.IsFav = isFav;
            infoVM.Product = product;
            return View("Info", infoVM);
        }
    }
}
