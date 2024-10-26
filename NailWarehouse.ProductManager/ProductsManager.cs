using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;
using NailWarehouse.ProductManager.Models;

namespace NailWarehouse.ProductManager
{
    /// <inheritdoc cref="IProductManager"/>
    public class ProductsManager : IProductManager
    {
        private readonly IProductStorage productStorage;
        private readonly ILogger logger;
        private const string TimeLoggerTemplate = "{0} выполнился за {1} мс";

        public ProductsManager(IProductStorage productStorage, ILogger logger)
        {
            this.productStorage = productStorage;
            this.logger = logger;
        }

        /// <inheritdoc cref="IProductManager.AddAsync(Product)"/>
        public async Task<Product> AddAsync(Product product)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = await productStorage.AddAsync(product);
            stopwatch.Stop();

            logger.LogDebug(string.Format(TimeLoggerTemplate, nameof(AddAsync), stopwatch.ElapsedMilliseconds));
            return result;
        }

        /// <inheritdoc cref="IProductManager.DeleteAsync(Guid)"/>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = await productStorage.DeleteAsync(id);
            if (result)
            {
                logger.LogDebug($"Продукт {id} удален");
            }
            stopwatch.Stop();

            logger.LogDebug(string.Format(TimeLoggerTemplate, nameof(DeleteAsync), stopwatch.ElapsedMilliseconds));
            return result;
        }

        /// <inheritdoc cref="IProductManager.EditAsync(Product)"/>
        public Task EditAsync(Product product)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = productStorage.EditAsync(product);
            stopwatch.Stop();

            logger.LogDebug(string.Format(TimeLoggerTemplate, nameof(EditAsync), stopwatch.ElapsedMilliseconds));
            return result;
        }

        /// <inheritdoc cref="IProductManager.GetAllAsync"/>
        public Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            var result = productStorage.GetAllAsync();
            stopwatch.Stop();

            logger.LogDebug(string.Format(TimeLoggerTemplate, nameof(GetAllAsync), stopwatch.ElapsedMilliseconds));
            return result;
        }

        /// <inheritdoc cref="IProductManager.GetStatsAsync"/>
        public async Task<IProductStats> GetStatsAsync()
        {
            var product = await productStorage.GetAllAsync();
            return new ProductStatsModel
            {
                TotalAmount = product.Count,
                FullPriceNoNds = product.Select(x => x.Quantity * x.Price).Sum(),
                FullPriceWithNds = product.Select(x => x.Quantity * x.Price).Sum() * 1.2m,
            };
        }
    }
}
