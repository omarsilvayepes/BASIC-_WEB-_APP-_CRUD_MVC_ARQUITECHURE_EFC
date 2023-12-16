using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Upsert(int? id) // for show the view to the user 
        {
            IEnumerable<SelectListItem> categoryList = _unitOfWork._categoryRepository
                .GetAll().Result
                .Select(c=> new SelectListItem
                {
                    Text=c.Name,
                    Value=c.Id.ToString()
                });

            ProductViewModel productViewModel = new ()
            {
                product=new Product(),
                categoryList=categoryList
            };
            if(id==null || id == 0) 
            {
                // Create

                //ViewBag.CategoryList = categoryList; //form 1: viewBag help to pass from controller to view only  temporal data when data is no save in any Model
                //ViewData["CategoryList"]=categoryList; //form 2

                return View(productViewModel); // form 3
            }
            else
            {
                //Update
                productViewModel.product = _unitOfWork._productRepository.Get(p=>p.Id==id).Result;
                return View(productViewModel);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Product product,string? file) // for save changes in DB
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
