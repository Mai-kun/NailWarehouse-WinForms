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
        public Task EditAsync(Product newProduct)
        {
            var target = this.product.FirstOrDefault(x => x.Id == newProduct.Id);
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
            return Task.FromResult<IReadOnlyCollection<Product>>(product);
        }
    }
}