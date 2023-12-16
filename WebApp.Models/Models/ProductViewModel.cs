
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models.Models
{
    public class ProductViewModel // Model specif for only view
    {
        public Product product { get; set; }
        public IEnumerable<SelectListItem> categoryList { get; set; }

    }
}
