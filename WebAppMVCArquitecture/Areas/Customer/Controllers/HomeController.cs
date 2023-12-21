using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.DataAcces.Repository.IRepository;
using WebApp.Models.Models;
using WebAppMVCArquitecture.Models;

namespace WebAppMVCArquitecture.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> listProducts = _unitOfWork._productRepository
                .GetAll(includeProperties: "Category")
                .Result.ToList();
            return View(listProducts);
        }

        public IActionResult Details(int? productId)
        {
            Product product = _unitOfWork._productRepository
                .Get(p=> p.Id== productId, includeProperties: "Category")
                .Result;
            return View(product); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
