using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Domain.Persistence.Configurations
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
       public DbSet<Product> Products;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ProductDbContext).Assembly);
        }
    }
}
