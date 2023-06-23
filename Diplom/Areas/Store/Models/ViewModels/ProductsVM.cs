using Diplom.Models;

namespace Diplom.Areas.Store.Models.ViewModels
{
    public class ProductsVM
    {
        public List<Product>? Products { get; set; }
        public List<Category>? Categories { get; set; }
        public Category? CurrentCategory { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
