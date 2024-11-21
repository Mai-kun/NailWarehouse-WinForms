using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Storage.Memory
{
    /// <inheritdoc cref="IProductStorage"/>
    public class MemoryProductStorage : IProductStorage
    {
        private readonly List<Product> products;

        public MemoryProductStorage()
        {
            products = new List<Product>();
        }

        /// <inheritdoc />
        public Task<Product> AddAsync(Product product)
        {
            this.products.Add(product);
            return Task.FromResult(product);
        }

        /// <inheritdoc />
        public Task<bool> DeleteAsync(Guid id)
        {
            var product = this.products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                this.products.Remove(product);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        /// <inheritdoc />
        public Task EditAsync(Product newProduct)
        {
            var target = this.products.FirstOrDefault(x => x.Id == newProduct.Id);
            if (target != null)
            {
                target.Id = newProduct.Id;
                target.Name = newProduct.Name;
                target.Size = newProduct.Size;
                target.Material = newProduct.Material;
                target.Quantity = newProduct.Quantity;
                target.MinimumQuantity = newProduct.MinimumQuantity;
                target.Price = newProduct.Price;
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            return Task.FromResult<IReadOnlyCollection<Product>>(products);
        }
    }
}
