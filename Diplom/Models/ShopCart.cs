using System.ComponentModel;

namespace Diplom.Models
{
    public class Shopcart
    {
        public Shopcart () { }
        public int Id { get; set; }
        [DefaultValue("current")]
        public string? Status { get; set; }
        public User User{ get; set; }
        public List<AddedProduct> Products { get; set; } = new();
    }
}
