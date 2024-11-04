using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Storage.Memory
{
    /// <inheritdoc cref="IProductStorage"/>
    public class MemoryProductStorage : IProductStorage
    {
        private readonly List<Product> product;

        public MemoryProductStorage()
        {
            product = new List<Product>();
        }

        /// <inheritdoc />
        public Task<Product> AddAsync(Product product)
        {
            this.product.Add(product);
            return Task.FromResult(product);
        }

        /// <inheritdoc />
        public Task<bool> DeleteAsync(Guid id)
        {
            var product = this.product.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                this.product.Remove(product);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        /// <inheritdoc />
        public Task EditAsync(Product product)
        {
            var target = this.product.FirstOrDefault(x => x.Id == product.Id);
            if (target != null)
            {
                target.Id = product.Id;
                target.Name = product.Name;
                target.Size = product.Size;
                target.Material = product.Material;
                target.Quantity = product.Quantity;
                target.MinimumQuantity = product.MinimumQuantity;
                target.Price = product.Price;
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            return Task.FromResult<IReadOnlyCollection<Product>>(product);
        }
    }
}
