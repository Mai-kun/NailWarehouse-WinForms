using System.Data.Entity;
using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Database
{
    /// <inheritdoc cref="IProductStorage"/>
    public class ProductStorage : IProductStorage
    {
        async Task<Product> IProductStorage.AddAsync(Product product)
        {
            using var context = new NailWarehouseDbContext();
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        async Task<bool> IProductStorage.DeleteAsync(Guid id)
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

        async Task IProductStorage.EditAsync(Product newProduct)
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

        async Task<IReadOnlyCollection<Product>> IProductStorage.GetAllAsync()
        {
            using var context = new NailWarehouseDbContext();
            var products = await context.Products
                .AsNoTracking()
                .ToListAsync();

            return products;
        }
    }
}
