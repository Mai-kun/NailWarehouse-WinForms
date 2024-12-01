using System.Configuration;
using System.Data.Entity;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Database
{
    public class NailWarehouseDbContext : DbContext
    {
        public NailWarehouseDbContext()
            : base("NailWarehouseDatabase")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
