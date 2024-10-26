using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;
using NailWarehouse.ProductManager.Models;

namespace NailWarehouse.ProductManager
{
    /// <inheritdoc cref="IProductManager"/>
    public class ProductsManager : IProductManager
    {
        private IProductStorage productStorage;

        public ProductsManager(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        /// <inheritdoc cref="IProductManager.AddAsync(Product)"/>
        public async Task<Product> AddAsync(Product product)
        {
            var result = await productStorage.AddAsync(product);
            return result;
        }

        /// <inheritdoc cref="IProductManager.DeleteAsync(Guid)"/>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await productStorage.DeleteAsync(id);
            return result;
        }

        /// <inheritdoc cref="IProductManager.EditAsync(Product)"/>
        public Task EditAsync(Product product)
            => productStorage.EditAsync(product);

        /// <inheritdoc cref="IProductManager.GetAllAsync"/>
        public Task<IReadOnlyCollection<Product>> GetAllAsync()
            => productStorage.GetAllAsync();

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
