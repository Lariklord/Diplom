using Diplom.Models;

namespace Diplom.Areas.Admin.Models.ViewModels
{
    public class ProductsPanelVm
    {
        public List<Product>? Products { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
