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
        private const string TimeTemplateLogger = "{Operation} выполнился за {ElapsedMilliseconds} мс";

        public ProductsManager(IProductStorage productStorage, ILogger logger)
        {
            this.productStorage = productStorage;
            this.logger = logger;
        }

        /// <inheritdoc />
        public async Task<Product> AddAsync(Product product)
        {
            var result = await StopwatchWrapper.MeasureExecutionTimeAsync(
                async () => await productStorage.AddAsync(product),
                logger,
                nameof(AddAsync),
                TimeTemplateLogger
            );

            logger.LogInformation("Продукт добавлен. Примечание: {@Product}", product);
            return result;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await StopwatchWrapper.MeasureExecutionTimeAsync(
                async () => await productStorage.DeleteAsync(id),
                logger,
                nameof(DeleteAsync),
                TimeTemplateLogger
            );

            if (result)
            {
                logger.LogInformation("Продукт {Id} удален", id);
            }
            else
            {
                logger.LogInformation("Не удалось удалить продукта {Id}", id);
            }

            return result;
        }

        /// <inheritdoc />
        public Task EditAsync(Product product)
        {
            return StopwatchWrapper.MeasureExecutionTimeAsync(
                () => productStorage.EditAsync(product),
                logger,
                nameof(EditAsync),
                TimeTemplateLogger
            );
        }

        /// <inheritdoc />
        public Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            return StopwatchWrapper.MeasureExecutionTimeAsync(
                () => productStorage.GetAllAsync(),
                logger,
                nameof(GetAllAsync),
                TimeTemplateLogger
            );
        }

        /// <inheritdoc />
        public async Task<IProductStats> GetStatsAsync()
        {
            var product = await StopwatchWrapper.MeasureExecutionTimeAsync(
                () => productStorage.GetAllAsync(),
                logger,
                nameof(GetStatsAsync),
                TimeTemplateLogger
            );

            return new ProductStatsModel
            {
                TotalAmount = product.Count,
                FullPriceNoNds = product.Select(x => x.Quantity * x.Price).Sum(),
                FullPriceWithNds = product.Select(x => x.Quantity * x.Price).Sum() * 1.2m,
            };
        }
    }
}
