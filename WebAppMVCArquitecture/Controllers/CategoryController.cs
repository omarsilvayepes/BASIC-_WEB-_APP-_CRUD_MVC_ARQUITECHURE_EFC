using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMVCArquitecture.Data;
using WebAppMVCArquitecture.Models;

namespace WebAppMVCArquitecture.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> listCategories=_dbContext.Categories.ToList();
            return View(listCategories);
        }
    }
}
