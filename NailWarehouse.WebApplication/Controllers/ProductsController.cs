using Microsoft.AspNetCore.Mvc;
using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.WebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductManager productManager;

        public ProductsController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        /// <summary>
        /// Отображает список всех продуктов.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var products = productManager.GetAllAsync();
            var stats = productManager.GetStatsAsync();
            await Task.WhenAll(products, stats);

            ViewData[nameof(IProductStats)] = stats.Result;
            return View(products.Result);
        }

        /// <summary>
        /// Отображает страницу создания нового продукта.
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Создает новый продукт.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            product.Id = Guid.NewGuid();
            await productManager.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу редактирования продукта по его идентификатору.
        /// </summary>
        public async Task<IActionResult> Edit(Guid id)
        {
            var products = await productManager.GetAllAsync();
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Редактирует существующий продукт.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var products = await productManager.GetAllAsync();
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            await productManager.EditAsync(product);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Удаляет продукт по его идентификатору.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await productManager.DeleteAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу конфиденциальности.
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
