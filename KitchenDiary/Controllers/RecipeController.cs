using KitchenDiary.Data;
using KitchenDiary.Models;
using Microsoft.AspNetCore.Mvc;
/* SelectList kullanmak için eklendi */
using Microsoft.AspNetCore.Mvc.Rendering; 


namespace KitchenDiary.Controllers
{
    public class RecipeController : Controller
    {
        // /Recipe veya /Recipe/Index
        public IActionResult Index()
        {
            return View(FakeData.Recipes);
        }

        // /Recipe/Details/3
        public IActionResult Details(int id)
        {
            var recipe = FakeData.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            ViewBag.CategoryName = FakeData.Categories
                .FirstOrDefault(c => c.Id == recipe.CategoryId)?.Name;

            return View(recipe);
        }

        /* GET: /Recipe/Create
        Formu BOŞ olarak gösterir. 
        */

        [HttpGet]
        public IActionResult Create()
        {
            // Açılır liste için: "Id" arka planda gönderilen değer, "Name" ekranda görünen yazı.
            //Kategori ismini, Tarifte tutmadığımız için
            ViewBag.Categories = new SelectList(FakeData.Categories, "Id", "Name");

            // Form boş bir ViewModel nesnesine bağlanır.
            return View(new RecipeCreateViewModel());
        }

        // POST: /Recipe/Create
        // Form gönderilince çalışır: ViewModel'i Recipe'ye çevirip listeye ekler.
        // Malzemeler ve adımlar formdan tek bir metin olarak gelir; Recipe sınıfı
        // List<string> beklediği için Split ile satırlardan bölüp ToList ile listeye çeviriyoruz.
        [HttpPost]
        public IActionResult Create(RecipeCreateViewModel model)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(FakeData.Categories, "Id", "Name");
                return View(model);
            }

            var recipe = new Recipe
            {
                Id = FakeData.Recipes.Max(r => r.Id) + 1,
                Title = model.Title,
                Description = model.Description,
                PrepTime = model.PrepTime,
                CookTime = model.CookTime,
                Servings = model.Servings,
                CategoryId = model.CategoryId,
                Rating = 0,
                ImageUrl = "https://images.unsplash.com/photo-1547592166-23ac45744acd?w=600&auto=format&fit=crop&q=80",
                Ingredients = model.IngredientsText
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList(),
                Steps = model.StepsText
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList()
            };

            FakeData.Recipes.Add(recipe);

            return RedirectToAction("Index");
        }
    }
}