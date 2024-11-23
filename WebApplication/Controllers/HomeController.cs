using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NailWarehouse.Contracts.Models;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly List<Product> products = new();

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductForm()
        {
            return View();
        }

        [HttpPut]
        public IActionResult ProductForm(Product product)
        {
            if (ModelState.IsValid)
            {
                // Здесь можно добавить код для сохранения продукта в базу данных
                return RedirectToAction("Index");
            }

            return View();
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
