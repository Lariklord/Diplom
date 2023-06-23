using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class Order
    {
        public Order() { }
        public int Id { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Entrance { get; set; }
        public string? Flour { get; set; }
        public string? Flat { get; set; }
        public string? Phone { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Price { get; set; }
        public int AccruedPoints { get; set; }
        public int SpentPoints { get; set; }
        public int ShopCartId { get; set; }
        public string Status { get; set; }
        public string? Comment { get; set; }
        public User User { get; set; }
        public Shopcart? ShopCart { get; set; }
    }
}
