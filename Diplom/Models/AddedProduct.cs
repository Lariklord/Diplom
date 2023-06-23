namespace Diplom.Models
{
    public class AddedProduct
    {
        public AddedProduct() { }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ShopCartId { get; set; }
        public Product? Product { get; set; }
    }
}
