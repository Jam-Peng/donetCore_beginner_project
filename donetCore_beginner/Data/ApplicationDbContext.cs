using donetCore_beginner.Models;
using Microsoft.EntityFrameworkCore;

namespace donetCore_beginner.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // 創建表格
        public DbSet<Category> Categories { get; set; }

        // 新增資料
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "產品一", DisplayOrder = 1 },
                new Category { CategoryID = 2, Name = "產品二", DisplayOrder = 2 },
                new Category { CategoryID = 3, Name = "產品三", DisplayOrder = 3 }
                );
        }
    }
}
