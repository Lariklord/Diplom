using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Diplom.Models
{
    public class User : IdentityUser
    {
        public User() { }  
        public string? FName { get; set; }

        public string? UserSurname { get; set; }
        [DefaultValue(0)]
        public int Points { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        [DefaultValue("card")]
        public string? PaymentMethod { get; set; }
        public List<Notification> Notifications { get; set; } = new();
        public List<FavouriteProduct> Favourites { get; set; } = new();
        public List<Shopcart> ShopCarts { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
        public int GetPoints()
        {
            return Points;
        }
    }
}
