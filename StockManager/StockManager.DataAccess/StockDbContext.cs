using Microsoft.EntityFrameworkCore;
using StockManager.Entities;
using System;

namespace StockManager.DataAccess
{
    public class StockDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAPTOP-52ID3BV9;Database=StockManagerDev;uid=sa;pwd=5154226aaa;");

        }

        public DbSet<Stocks> Stocks { get; set; }
    }
}
