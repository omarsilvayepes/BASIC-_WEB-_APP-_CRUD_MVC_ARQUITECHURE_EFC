using Microsoft.AspNetCore.Mvc;
using WebApp.DataAcces.Repository.IRepository;
using WebApp.Models.Models;

namespace WebAppMVCArquitecture.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> listProducts = _unitOfWork._productRepository.GetAll().Result.ToList();
            return View(listProducts);
        }

        public IActionResult Create() // for show the view to the user 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product) // for save changes in DB
        {
            if (ModelState.IsValid)
            {
                _unitOfWork._productRepository.Add(product);
                _unitOfWork.Save();
                TempData["Success"] = "Create Succesfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public IActionResult Edit(int? id) // for show the view to the user
        {
            if (id == null || id == 0) return NotFound();

            Product? productDb = _unitOfWork._productRepository.Get(c => c.Id == id).Result;
            if (productDb == null) return NotFound();

            return View(productDb);
        }

        [HttpPost]
        public IActionResult Edit(Product product) // for save changes in DB
        {
            if (ModelState.IsValid)
            {
                _unitOfWork._productRepository.Update(product);
                _unitOfWork.Save();
                TempData["Success"] = "Updated Succesfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public IActionResult Delete(int? id) // for show the view to the user
        {
            if (id == null || id == 0) return NotFound();

            Product? productDb = _unitOfWork._productRepository.Get(c => c.Id == id).Result;
            if (productDb == null) return NotFound();

            return View(productDb);
        }

        [HttpPost]
        public IActionResult Delete(Product product) // for save changes in DB
        {
            _unitOfWork._productRepository.Remove(product);
            _unitOfWork.Save();
            TempData["Success"] = "Deleted Succesfully";
            return RedirectToAction("Index", "Product");
        }
    }
}
