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

        /// <inheritdoc />
        public async Task<Product> AddAsync(Product product)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = await productStorage.AddAsync(product);
            stopwatch.Stop();

            logger.LogDebug(TimeLoggerTemplate, nameof(AddAsync), stopwatch.ElapsedMilliseconds);
            return result;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(Guid id)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = await productStorage.DeleteAsync(id);
            if (result)
            {
                logger.LogDebug($"Продукт {id} удален");
            }
            stopwatch.Stop();

            logger.LogDebug(TimeLoggerTemplate, nameof(DeleteAsync), stopwatch.ElapsedMilliseconds);
            return result;
        }

        /// <inheritdoc />
        public Task EditAsync(Product product)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = productStorage.EditAsync(product);
            stopwatch.Stop();

            logger.LogDebug(TimeLoggerTemplate, nameof(EditAsync), stopwatch.ElapsedMilliseconds);
            return result;
        }

        /// <inheritdoc />
        public Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            var result = productStorage.GetAllAsync();
            stopwatch.Stop();

            logger.LogDebug(TimeLoggerTemplate, nameof(GetAllAsync), stopwatch.ElapsedMilliseconds);
            return result;
        }

        /// <inheritdoc />
        public async Task<IProductStats> GetStatsAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            var product = await productStorage.GetAllAsync();
            stopwatch.Stop();
            logger.LogDebug(TimeLoggerTemplate, nameof(GetStatsAsync), stopwatch.ElapsedMilliseconds);

            return new ProductStatsModel
            {
                TotalAmount = product.Count,
                FullPriceNoNds = product.Select(x => x.Quantity * x.Price).Sum(),
                FullPriceWithNds = product.Select(x => x.Quantity * x.Price).Sum() * 1.2m,
            };
        }
    }
}
