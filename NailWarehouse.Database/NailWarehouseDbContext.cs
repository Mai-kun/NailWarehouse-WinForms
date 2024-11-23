using System.Configuration;
using Microsoft.EntityFrameworkCore;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Database
{
    public class NailWarehouseDbContext : DbContext
    {
        public NailWarehouseDbContext()
            : base(GetOptions("Server=.;Database=DataGridView;Trusted_Connection=True;")) { }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }

        public DbSet<Product> Products { get; set; }
    }
}
