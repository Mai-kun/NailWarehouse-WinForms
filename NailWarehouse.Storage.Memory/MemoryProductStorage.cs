using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Storage.Memory
{
    /// <summary>
    /// Класс для управления ведения хранилища
    /// </summary>
    public class MemoryProductStorage : IProductStorage
    {
        private List<Product> product;

        public MemoryProductStorage()
        {
            product = new List<Product>();
        }

        /// <summary>
        /// <inheritdoc cref="IProductStorage.AddAsync(Product)"/>
        /// </summary>
        public Task<Product> AddAsync(Product product)
        {
            this.product.Add(product);
            return Task.FromResult(product);
        }

        /// <summary>
        /// <inheritdoc cref="IProductStorage.DeleteAsync(Guid)"/>
        /// </summary>
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

        /// <summary>
        /// <inheritdoc cref="IProductStorage.EditAsync(Product)"/>
        /// </summary>
        public Task EditAsync(Product product)
        {
            var target = this.product.FirstOrDefault(x => x.Id == product.Id);
            if (product != null)
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

        /// <summary>
        /// <inheritdoc cref="IProductStorage.GetAllAsync"/>
        /// </summary>
        public Task<IReadOnlyCollection<Product>> GetAllAsync()
            => Task.FromResult<IReadOnlyCollection<Product>>(product);
    }
}
