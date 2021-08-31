using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCrud.Contexts
{
    public class ProjectDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Product> Product { get; set; }
    }
}
