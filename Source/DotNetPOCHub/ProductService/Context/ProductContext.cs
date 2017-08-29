using ProductContract.Model;
using System.Data.Entity;

namespace ProductService.Context
{
    internal class ProductContext : DbContext
    {
        public ProductContext(): base("ProductContext") {}

        public DbSet<Product> Products { get; set; }
    }
}
