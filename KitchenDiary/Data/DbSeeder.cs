using KitchenDiary.Models;

namespace KitchenDiary.Data
{
    // Uygulama açılırken veritabanı boşsa FakeData'daki verileri aktarır
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            // Zaten veri varsa hiçbir şey yapma
            if (db.Categories.Any())
                return;

            // FakeData'daki eski Id -> yeni oluşturulan Category nesnesi
            var categoryMap = new Dictionary<int, Category>();

            foreach (var c in FakeData.Categories)
            {
                var newCategory = new Category
                {
                    Name = c.Name,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl
                };
                categoryMap[c.Id] = newCategory;
                db.Categories.Add(newCategory);
            }

            foreach (var r in FakeData.Recipes)
            {
                db.Recipes.Add(new Recipe
                {
                    Title = r.Title,
                    Description = r.Description,
                    PrepTime = r.PrepTime,
                    CookTime = r.CookTime,
                    Servings = r.Servings,
                    Rating = r.Rating,
                    ImageUrl = r.ImageUrl,
                    Category = categoryMap[r.CategoryId],   // sayı değil, nesne
                    Ingredients = r.Ingredients
                        .Select(i => new Ingredient { Text = i.Text }).ToList(),
                    Steps = r.Steps
                        .Select(s => new RecipeStep { StepNumber = s.StepNumber, Text = s.Text }).ToList()
                });
            }

            db.SaveChanges();   // hepsini tek seferde SQL Server'a yazar
        }
    }
}