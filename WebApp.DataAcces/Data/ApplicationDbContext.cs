using Microsoft.EntityFrameworkCore;
using WebApp.Models.Models;
using WebAppMVCArquitecture.Models;

namespace WebAppMVCArquitecture.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        // set some data(seed)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Service",DisplayOrder=1},
                new Category { Id = 2, Name = "Tecnology", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Transports", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 1,
                    Title = "Fortune of time",
                    Author = "Billy Spark",
                    Description = "Description",
                    ISBN="SW13465789",
                    ListPrice=99,
                    Price=98,
                    Price50=85,
                    Price100=80,
                    CategoryId=1,
                    ImageUrl=""

                },
                 new Product
                 {
                     Id = 2,
                     Title = "Fortune of time",
                     Author = "Billy Spark",
                     Description = "Description",
                     ISBN = "SW13465789",
                     ListPrice = 99,
                     Price = 98,
                     Price50 = 85,
                     Price100 = 80,
                     CategoryId=2,
                     ImageUrl=""

                 }
                );
        }
    }
}
