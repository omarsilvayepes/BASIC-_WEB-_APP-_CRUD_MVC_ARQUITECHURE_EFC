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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name","The Name Can Not exactly match with the Display Order Field");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
