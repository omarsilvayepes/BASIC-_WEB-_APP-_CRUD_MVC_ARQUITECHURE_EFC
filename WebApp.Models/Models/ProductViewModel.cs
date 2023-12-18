
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models.Models
{
    public class ProductViewModel // Model specif for only view
    {
        public Product product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> categoryList { get; set; }

    }
}
