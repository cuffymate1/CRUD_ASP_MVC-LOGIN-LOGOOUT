using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) //constructor DbContext
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder= 1}, // กำหนดข้อมูล ลง DataBase จากนั้น =>
                new Category { Id = 2, Name = "Scifi", DisplayOrder= 2}, // ใช้คำสั่ง add-migration SeedCategoryTable
                new Category { Id = 3, Name = "History", DisplayOrder= 3}
                );
        }


        public DbSet<Users> Users { get; set; }
    }
}
