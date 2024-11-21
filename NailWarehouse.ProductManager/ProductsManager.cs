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

        public ProductsManager(IProductStorage productStorage, ILogger logger)
        {
            this.productStorage = productStorage;
            this.logger = logger;
        }

        /// <inheritdoc />
        public async Task<Product> AddAsync(Product product)
        {
            var result = await StopwatchWrapper.MeasureExecutionTimeAsync(
                () => productStorage.AddAsync(product),
                logger,
                nameof(AddAsync)
            );

            logger.LogInformation("Продукт добавлен. Примечание: {@Product}", product);
            return result;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await StopwatchWrapper.MeasureExecutionTimeAsync(
                () => productStorage.DeleteAsync(id),
                logger,
                nameof(DeleteAsync)
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
                nameof(EditAsync)
            );
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            return await StopwatchWrapper.MeasureExecutionTimeAsync(
                () => productStorage.GetAllAsync(),
                logger,
                nameof(GetAllAsync)
            );
        }

        /// <inheritdoc />
        public async Task<IProductStats> GetStatsAsync()
        {
            return await StopwatchWrapper.MeasureExecutionTimeAsync(
                async () =>
                {
                    var product = await productStorage.GetAllAsync();
                    return new ProductStatsModel
                    {
                        TotalAmount = product.Count,
                        FullPriceNoNds = product.Select(x => x.Quantity * x.Price).Sum(),
                        FullPriceWithNds = product.Select(x => x.Quantity * x.Price).Sum() * 1.2m,
                    };
                },
                logger,
                nameof(GetStatsAsync)
            );
        }
    }
}