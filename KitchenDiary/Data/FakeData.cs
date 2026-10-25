using KitchenDiary.Models;
using System.Collections.Generic;

namespace KitchenDiary.Data
{
    public static class FakeData
    {
        // Verilen metinleri Ingredient nesnelerine çevirir
        private static List<Ingredient> Malzemeler(params string[] metinler) =>
            metinler.Select(m => new Ingredient { Text = m }).ToList();

        // Verilen metinleri sırayla numaralandırıp RecipeStep nesnelerine çevirir
        private static List<RecipeStep> Adimlar(params string[] metinler) =>
            metinler.Select((m, i) => new RecipeStep { StepNumber = i + 1, Text = m }).ToList();
        private static List<Category>? _categories;
        public static List<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new List<Category>
                    {
                        new Category
                        {
                            Id = 1,
                            Name = "Çorbalar",
                            ImageUrl = "https://images.unsplash.com/photo-1547592166-23ac45744acd?w=800&auto=format&fit=crop&q=80",
                            Description = "Sıcacık, doyurucu çorba tarifleri"
                        },
                        new Category
                        {
                            Id = 2,
                            Name = "Ana Yemekler",
                            ImageUrl = "https://images.unsplash.com/photo-1544025162-d76694265947?w=800&auto=format&fit=crop&q=80",
                            Description = "Sofranın yıldızı ana yemekler"
                        },
                        new Category
                        {
                            Id = 3,
                            Name = "Tatlılar",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRlbSqSrKgcpHmf1HOaS84S9AOoOe1VhqJVwf2Axf6mRQ&s=10",
                            Description = "Tatlı krizlerine özel lezzetler"
                        }
                    };
                }
                return _categories;
            }
        }

        public static List<Recipe> Recipes = new()
        {
            new Recipe
            {
                Id = 1, Title = "Mercimek Çorbası", CategoryId = 1,
                Description = "Klasik, kremamsı kırmızı mercimek çorbası.",
                PrepTime = 10, CookTime = 25, Servings = 4, Rating = 4.8,
                ImageUrl = "https://images.unsplash.com/photo-1547592166-23ac45744acd?w=800&auto=format&fit=crop&q=80",
                Ingredients = Malzemeler ( "1 su bardağı kırmızı mercimek", "1 adet soğan", "1 adet havuç", "1 yemek kaşığı tereyağı", "6 su bardağı su", "Tuz, karabiber" ),
                Steps = Adimlar ( "Soğan ve havucu doğrayıp tereyağında kavurun.", "Yıkanmış mercimeği ve suyu ekleyin.", "Mercimekler yumuşayana kadar yaklaşık 25 dakika pişirin.", "Blenderdan geçirip tuz ve baharatla servis edin." )
            },
            new Recipe
            {
                Id = 2, Title = "Ezogelin Çorbası", CategoryId = 1,
                Description = "Baharatlı ve ferahlatıcı geleneksel çorba.",
                PrepTime = 10, CookTime = 30, Servings = 5, Rating = 4.6,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNOBzRQ4bVZPPAPvWikLnfGn0YLTZBac-oExhEd71uDQ&s=10",
                Ingredients = Malzemeler ( "1 su bardağı kırmızı mercimek", "2 yemek kaşığı bulgur", "1 yemek kaşığı domates salçası", "1 adet soğan", "Nane, pul biber" ),
                Steps = Adimlar ( "Soğanı salçayla kavurun.", "Mercimek, bulgur ve suyu ekleyin.", "30 dakika kaynatın.", "Nane ve pul biberle servis edin." )
            },
            new Recipe
            {
                Id = 3, Title = "Karnıyarık", CategoryId = 2,
                Description = "Kıymalı patlıcan yemeklerinin kralı.",
                PrepTime = 30, CookTime = 40, Servings = 4, Rating = 4.9,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQjbX8HYFNmhCdxOx7ce_sOOusDnQImaBt5joYfyLHBLw&s=10",
                Ingredients = Malzemeler ( "4 adet patlıcan", "250 gr kıyma", "2 adet soğan", "2 adet domates", "Sivri biber, tuz, karabiber" ),
                Steps = Adimlar ( "Patlıcanları alacalı soyup kızartın.", "Kıymayı soğanla kavurup iç harcı hazırlayın.", "Patlıcanları yarıp içini doldurun.", "Fırında 40 dakika pişirin." )
            },
            new Recipe
            {
                Id = 4, Title = "Tavuk Sote", CategoryId = 2,
                Description = "Pratik, hızlı ve lezzetli bir akşam yemeği.",
                PrepTime = 15, CookTime = 20, Servings = 3, Rating = 4.5,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQikTTPJLekFiY6g5FGBQOPFcrkkKMVEI8K0Xcz1vdOXQ&s=10",
                Ingredients = Malzemeler ( "500 gr tavuk göğsü", "2 adet biber", "2 adet domates", "1 adet soğan", "Zeytinyağı, tuz, baharat" ),
                Steps = Adimlar ( "Tavukları küp küp doğrayıp soteleyin.", "Soğan ve biberleri ekleyin.", "Domatesleri ekleyip kısık ateşte pişirin." )
            },
            new Recipe
            {
                Id = 5, Title = "Sütlaç", CategoryId = 3,
                Description = "Fırınlanmış, üstü kızarmış ev yapımı sütlaç.",
                PrepTime = 10, CookTime = 35, Servings = 6, Rating = 4.7,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQhA4-s-UQuX6W9rRPH9aN5oPRh5REQSZaGSXF1rMlM3g&s=10",
                Ingredients = Malzemeler ( "1 litre süt", "½ su bardağı pirinç", "¾ su bardağı şeker", "1 yemek kaşığı nişasta", "Vanilin" ),
                Steps = Adimlar ( "Pirinci haşlayın.", "Süt ve şekeri ekleyip kaynatın.", "Nişastalı karışımı ilave edip koyulaştırın.", "Kaselere paylaştırıp fırında üstünü kızartın." )
            },
            new Recipe
            {
                Id = 6, Title = "Revani", CategoryId = 3,
                Description = "Şerbetli, yumuşacık irmikli tatlı.",
                PrepTime = 20, CookTime = 30, Servings = 8, Rating = 4.4,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT9nbniV6EArAk91Z81MM-NhyTgSX0t0nP8wYvY8e9l3w&s=10",
                Ingredients = Malzemeler ( "3 adet yumurta", "1 su bardağı şeker", "1 su bardağı irmik", "1 su bardağı un", "1 paket kabartma tozu", "Şerbet için su ve şeker" ),
                Steps = Adimlar ( "Yumurta ve şekeri çırpın.", "Kuru malzemeleri ekleyip karıştırın.", "Tepsiye dökün ve 30 dakika pişirin.", "Soğuyan şerbeti sıcak tatlıya dökün." )
            }
        };
    }
}