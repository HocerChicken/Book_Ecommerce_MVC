using Book_Ecommerce_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Ecommerce_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var categoryList = new List<Category>()
            {
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            };
            modelBuilder.Entity<Category>().HasData(categoryList);
        }
    }
}
