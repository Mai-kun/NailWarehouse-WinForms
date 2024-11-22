using Microsoft.EntityFrameworkCore;
using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Database
{
    /// <inheritdoc cref="IProductStorage"/>
    public class ProductStorage : IProductStorage
    {
        public async Task<Product> AddAsync(Product product)
        {
            using var context = new NailWarehouseDbContext();
            await context.AddAsync(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using var context = new NailWarehouseDbContext();
            var products = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (products == null)
            {
                return false;
            }

            context.Products.Remove(products);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task EditAsync(Product newProduct)
        {
            using var context = new NailWarehouseDbContext();
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == newProduct.Id);
            if (product == null)
            {
                return;
            }
            product.Name = newProduct.Name;
            product.Size = newProduct.Size;
            product.Material = newProduct.Material;
            product.Quantity = newProduct.Quantity;
            product.MinimumQuantity = newProduct.MinimumQuantity;
            product.Price = newProduct.Price;
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            using var context = new NailWarehouseDbContext();
            var products = await context.Products
                .AsNoTracking()
                .ToListAsync();

            return products;
        }
    }
}