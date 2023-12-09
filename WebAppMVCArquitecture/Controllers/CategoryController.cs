using Microsoft.AspNetCore.Mvc;
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
            List<Category> listCategories = _dbContext.Categories.ToList();
            return View(listCategories);
        }

        public IActionResult Create() // for show the view to the user 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category) // for save changes in DB
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name Can Not exactly match with the Display Order Field");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                TempData["Success"] = "Create Succesfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Edit(int? id) // for show the view to the user
        {
            if (id == null || id == 0) return NotFound();

            Category? categoryDb = _dbContext.Categories.FirstOrDefault(c=> c.Id == id);
            if (categoryDb == null) return NotFound();

            return View(categoryDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category) // for save changes in DB
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                TempData["Success"] = "Updated Succesfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? id) // for show the view to the user
        {
            if (id == null || id == 0) return NotFound();

            Category? categoryDb = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryDb == null) return NotFound();

            return View(categoryDb);
        }

        [HttpPost]
        public IActionResult Delete(Category category) // for save changes in DB
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            TempData["Success"] = "Deleted Succesfully";
            return RedirectToAction("Index", "Category");
        }

    }
}
