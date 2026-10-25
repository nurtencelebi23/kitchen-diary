using KitchenDiary.Models;
using Microsoft.EntityFrameworkCore;

namespace KitchenDiary.Data
{
    // Uygulama ile SQL Server arasındaki köprü
    public class AppDbContext : DbContext
    {
        // Bağlantı ayarını dışarıdan (Program.cs) alır
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Her DbSet, veritabanında bir tabloya karşılık gelir
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Kategori silinirken içindeki tarifler zincirleme silinmesin
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}