using Microsoft.EntityFrameworkCore;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Database
{
    public class NailWarehouseDbContext : DbContext
    {
        public NailWarehouseDbContext() { }

        public NailWarehouseDbContext(DbContextOptions<NailWarehouseDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=C41406\\SQLEXPRESS;Database=DataGridView;Trusted_Connection=True;");
        }

        public DbSet<Product> Products { get; set; }
    }
}
