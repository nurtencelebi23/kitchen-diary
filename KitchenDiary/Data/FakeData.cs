
using KitchenDiary.Models;

namespace LezzetDefteri.Data
{
    public static class FakeData
    {
        public static List<Category> Categories = new()
        {
            new Category { Id = 1, Name = "Çorbalar", Description = "Sıcacık, doyurucu çorba tarifleri", ImageUrl = "/img/corbalar.jpg" },
            new Category { Id = 2, Name = "Ana Yemekler", Description = "Sofranın yıldızı ana yemekler", ImageUrl = "/img/ana-yemekler.jpg" },
            new Category { Id = 3, Name = "Tatlılar", Description = "Tatlı krizlerine özel lezzetler", ImageUrl = "/img/tatlilar.jpg" }
        };

        public static List<Recipe> Recipes = new()
        {
            new Recipe
            {
                Id = 1, Title = "Mercimek Çorbası", CategoryId = 1,
                Description = "Klasik, kremamsı kırmızı mercimek çorbası.",
                PrepTime = 10, CookTime = 25, Servings = 4, Rating = 4.8,
                ImageUrl = "/img/mercimek.jpg",
                Ingredients = new() { "1 su bardağı kırmızı mercimek", "1 adet soğan", "1 adet havuç", "1 yemek kaşığı tereyağı", "6 su bardağı su", "Tuz, karabiber" },
                Steps = new() { "Soğan ve havucu doğrayıp tereyağında kavurun.", "Yıkanmış mercimeği ve suyu ekleyin.", "Mercimekler yumuşayana kadar yaklaşık 25 dakika pişirin.", "Blenderdan geçirip tuz ve baharatla servis edin." }
            },
            new Recipe
            {
                Id = 2, Title = "Ezogelin Çorbası", CategoryId = 1,
                Description = "Baharatlı ve ferahlatıcı geleneksel çorba.",
                PrepTime = 10, CookTime = 30, Servings = 5, Rating = 4.6,
                ImageUrl = "/img/ezogelin.jpg",
                Ingredients = new() { "1 su bardağı kırmızı mercimek", "2 yemek kaşığı bulgur", "1 yemek kaşığı domates salçası", "1 adet soğan", "Nane, pul biber" },
                Steps = new() { "Soğanı salçayla kavurun.", "Mercimek, bulgur ve suyu ekleyin.", "30 dakika kaynatın.", "Nane ve pul biberle servis edin." }
            },
            new Recipe
            {
                Id = 3, Title = "Karnıyarık", CategoryId = 2,
                Description = "Kıymalı patlıcan yemeklerinin kralı.",
                PrepTime = 30, CookTime = 40, Servings = 4, Rating = 4.9,
                ImageUrl = "/img/karniyarik.jpg",
                Ingredients = new() { "4 adet patlıcan", "250 gr kıyma", "2 adet soğan", "2 adet domates", "Sivri biber, tuz, karabiber" },
                Steps = new() { "Patlıcanları alacalı soyup kızartın.", "Kıymayı soğanla kavurup iç harcı hazırlayın.", "Patlıcanları yarıp içini doldurun.", "Fırında 40 dakika pişirin." }
            },
            new Recipe
            {
                Id = 4, Title = "Tavuk Sote", CategoryId = 2,
                Description = "Pratik, hızlı ve lezzetli bir akşam yemeği.",
                PrepTime = 15, CookTime = 20, Servings = 3, Rating = 4.5,
                ImageUrl = "/img/tavuk-sote.jpg",
                Ingredients = new() { "500 gr tavuk göğsü", "2 adet biber", "2 adet domates", "1 adet soğan", "Zeytinyağı, tuz, baharat" },
                Steps = new() { "Tavukları küp küp doğrayıp soteleyin.", "Soğan ve biberleri ekleyin.", "Domatesleri ekleyip kısık ateşte pişirin." }
            },
            new Recipe
            {
                Id = 5, Title = "Sütlaç", CategoryId = 3,
                Description = "Fırınlanmış, üstü kızarmış ev yapımı sütlaç.",
                PrepTime = 10, CookTime = 35, Servings = 6, Rating = 4.7,
                ImageUrl = "/img/sutlac.jpg",
                Ingredients = new() { "1 litre süt", "½ su bardağı pirinç", "¾ su bardağı şeker", "1 yemek kaşığı nişasta", "Vanilin" },
                Steps = new() { "Pirinci haşlayın.", "Süt ve şekeri ekleyip kaynatın.", "Nişastalı karışımı ilave edip koyulaştırın.", "Kaselere paylaştırıp fırında üstünü kızartın." }
            },
            new Recipe
            {
                Id = 6, Title = "Revani", CategoryId = 3,
                Description = "Şerbetli, yumuşacık irmikli tatlı.",
                PrepTime = 20, CookTime = 30, Servings = 8, Rating = 4.4,
                ImageUrl = "/img/revani.jpg",
                Ingredients = new() { "3 adet yumurta", "1 su bardağı şeker", "1 su bardağı irmik", "1 su bardağı un", "1 paket kabartma tozu", "Şerbet için su ve şeker" },
                Steps = new() { "Yumurta ve şekeri çırpın.", "Kuru malzemeleri ekleyip karıştırın.", "Tepsiye dökün ve 30 dakika pişirin.", "Soğuyan şerbeti sıcak tatlıya dökün." }
            }
        };
    }
}