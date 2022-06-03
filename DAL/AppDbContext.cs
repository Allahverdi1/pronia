using Microsoft.EntityFrameworkCore;
using proniaTask.Models;

namespace proniaTask.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options):base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> productImages { get; set; }
        public DbSet<OurProduct> OurProducts { get; set; }
    }
}
