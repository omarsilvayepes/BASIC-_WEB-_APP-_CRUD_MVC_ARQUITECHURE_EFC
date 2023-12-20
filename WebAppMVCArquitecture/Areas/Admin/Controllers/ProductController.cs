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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> listProducts = _unitOfWork._productRepository.GetAll(includeProperties: "Category").Result.ToList();
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
        public  IActionResult Upsert(ProductViewModel productViewModel,IFormFile? file) // for save changes in DB
        {
            if (ModelState.IsValid)
            {
                // save file

                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\Product");

                    //Validate if it is update file

                    if (!string.IsNullOrEmpty(productViewModel.product.ImageUrl))
                    {
                        //Delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, productViewModel.product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath)) { System.IO.File.Delete(oldImagePath); }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyToAsync(fileStream);
                    }

                    productViewModel.product.ImageUrl = @"\Images\Product\" + fileName;
                }

                if (productViewModel.product.Id == 0)
                {
                    _unitOfWork._productRepository.Add(productViewModel.product);
                    TempData["Success"] = "Create Succesfully";
                }
                else
                {
                    _unitOfWork._productRepository.Update(productViewModel.product);
                    TempData["Success"] = "Update Succesfully";
                }
                
                _unitOfWork.Save();
                return RedirectToAction("Index", "Product");
            }
            return View();
        }



        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> listProducts = _unitOfWork._productRepository.GetAll(includeProperties: "Category").Result.ToList();
            return Json(new {data= listProducts });
        }

        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork._productRepository.Get(p=> p.Id==id).Result;
            if (productToBeDeleted==null)
            {
                return Json(new {success=false,message="Error while deleting"});
            }

            //Delete the old image
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath)) { System.IO.File.Delete(oldImagePath); }

            _unitOfWork._productRepository.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Product Deleted succesfully" });
        }
        #endregion 

    }
}
