﻿using System.Configuration;
using Microsoft.EntityFrameworkCore;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Database
{
    public class NailWarehouseDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DataGridView;Trusted_Connection=True;");
        }

        public DbSet<Product> Products { get; set; }
    }
}