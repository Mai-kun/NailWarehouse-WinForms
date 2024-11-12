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
        private const string TimeTemplateLogger = "{MethodName} выполнился за {Time} мс";

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

            logger.LogInformation("Продут добавлен. Примечание: {@Product}", product);
            logger.LogInformation(TimeTemplateLogger, nameof(AddAsync), stopwatch.ElapsedMilliseconds);
            return result;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(Guid id)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = await productStorage.DeleteAsync(id);
            if (result)
            {
                logger.LogInformation("Продукт {Id} удален", id);
            }
            else
            {
                logger.LogInformation("Не удалось удалить продукта {Id}", id);
            }
            stopwatch.Stop();

            logger.LogInformation(TimeTemplateLogger, nameof(DeleteAsync), stopwatch.ElapsedMilliseconds);
            return result;
        }

        /// <inheritdoc />
        public Task EditAsync(Product product)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = productStorage.EditAsync(product);
            stopwatch.Stop();

            logger.LogInformation(TimeTemplateLogger, nameof(EditAsync), stopwatch.ElapsedMilliseconds);
            return result;
        }

        /// <inheritdoc />
        public Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            var result = productStorage.GetAllAsync();
            stopwatch.Stop();

            logger.LogInformation(TimeTemplateLogger, nameof(GetAllAsync), stopwatch.ElapsedMilliseconds);
            return result;
        }

        /// <inheritdoc />
        public async Task<IProductStats> GetStatsAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            var product = await productStorage.GetAllAsync();
            stopwatch.Stop();
            logger.LogInformation(TimeTemplateLogger, nameof(GetStatsAsync), stopwatch.ElapsedMilliseconds);

            return new ProductStatsModel
            {
                TotalAmount = product.Count,
                FullPriceNoNds = product.Select(x => x.Quantity * x.Price).Sum(),
                FullPriceWithNds = product.Select(x => x.Quantity * x.Price).Sum() * 1.2m,
            };
        }
    }
}
