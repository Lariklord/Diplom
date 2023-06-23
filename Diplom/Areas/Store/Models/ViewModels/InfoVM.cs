using Diplom.Models;

namespace Diplom.Areas.Store.Models.ViewModels
{
    public class InfoVM
    {
        public List<Category>? Categories { get; set; }
        public Product? Product { get; set; }
        public bool IsFav { get; set; }
        public int AddedCount { get; set; }
    }
}
