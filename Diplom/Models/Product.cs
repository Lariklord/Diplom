namespace Diplom.Models
{
    public class Product
    {
        public Product() { }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Composition { get; set; }
        public int Code { get; set; }
        public string? ShelfLife { get; set; }
        public decimal Price { get; set; }
        public string? MainUrl { get; set; }
        public double Weight { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
