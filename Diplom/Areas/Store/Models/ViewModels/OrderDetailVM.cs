using Diplom.Models;

namespace Diplom.Areas.Store.Models.ViewModels
{
    public class OrderDetailVM
    {
        public Order? Order { get; set; }
        public User? User { get; set; }
        public Dictionary<Product, int>? Products { get; set; }
        public decimal Total { get; set; }
    }
}
