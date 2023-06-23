namespace Diplom.Models
{
    public class FavouriteProduct
    {
        public FavouriteProduct() { }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public User User { get; set; }
        public Product? Product { get; set; }
    }
}
