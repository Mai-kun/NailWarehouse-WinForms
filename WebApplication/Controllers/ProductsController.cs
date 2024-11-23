using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NailWarehouse.Contracts.Models;
using NailWarehouse.Database;

namespace NailWarehouse.WebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> logger;
        private readonly NailWarehouseDbContext context;

        public ProductsController(ILogger<ProductsController> logger,
            NailWarehouseDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await context.Products.ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            product.Id = Guid.NewGuid();
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var existingProduct = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            context.Entry(existingProduct).CurrentValues.SetValues(product);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
