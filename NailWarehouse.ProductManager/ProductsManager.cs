using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;
using NailWarehouse.ProductManager.Models;

namespace NailWarehouse.ProductManager
{
    /// <summary>
    /// Класс для управления хранилищем
    /// </summary>
    public class ProductsManager : IProductManager
    {
        private IProductStorage productStorage;

        public ProductsManager(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        /// <summary>
        /// <inheritdoc cref="IProductManager.AddAsync(Product)"/>
        /// </summary>
        public async Task<Product> AddAsync(Product product)
        {
            var result = await productStorage.AddAsync(product);
            return result;
        }

        /// <summary>
        /// <inheritdoc cref="IProductManager.DeleteAsync(Guid)"/>
        /// </summary>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await productStorage.DeleteAsync(id);
            return result;
        }

        /// <summary>
        /// <inheritdoc cref="IProductManager.EditAsync(Product)"/>
        /// </summary>
        public Task EditAsync(Product product)
            => productStorage.EditAsync(product);

        /// <summary>
        /// <inheritdoc cref="IProductManager.GetAllAsync"/>
        /// </summary>
        public Task<IReadOnlyCollection<Product>> GetAllAsync()
            => productStorage.GetAllAsync();

        /// <summary>
        /// <inheritdoc cref="IProductManager.GetStatsAsync"/>
        /// </summary>
        public async Task<IProductStats> GetStatsAsync()
        {
            var product = await productStorage.GetAllAsync();
            return new ProductStatsModel
            {
                TotalAmount = product.Count,
                FullPriceNoNDS = product.Select(x => x.Quantity * x.Price).Sum(),
                FullPriceWithNDS = product.Select(x => x.Quantity * x.Price).Sum() * 1.2m,
            };
        }
    }
}
