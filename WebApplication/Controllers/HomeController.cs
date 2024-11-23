using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.EntityFrameworkCore;
using NailWarehouse.Contracts.Models;
using NailWarehouse.Database;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly NailWarehouseDbContext context;

        public HomeController(ILogger<HomeController> logger,
            NailWarehouseDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProductForm(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = Guid.NewGuid();
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
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
