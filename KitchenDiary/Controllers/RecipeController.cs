using Microsoft.EntityFrameworkCore;
using KitchenDiary.Data;
using KitchenDiary.Models;
using Microsoft.AspNetCore.Mvc;
/* SelectList kullanmak için eklendi */
using Microsoft.AspNetCore.Mvc.Rendering; 


namespace KitchenDiary.Controllers
{
    public class RecipeController : Controller
    {
        private readonly AppDbContext _context;

        public RecipeController(AppDbContext context)
        {
            _context = context;
        }

        // /Recipe veya /Recipe/Index
        public IActionResult Index()
        {
            return View(_context.Recipes.ToList());
        }

        // /Recipe/Details/3
        public IActionResult Details(int id)
        {
            var recipe = _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Ingredients)
                .Include(r => r.Steps)
                .FirstOrDefault(r => r.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

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
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");

            // Form boş bir ViewModel nesnesine bağlanır.
            return View(new RecipeCreateViewModel());
        }

        // POST: /Recipe/Create
        // Form gönderilince çalışır: ViewModel'i Recipe'ye çevirip veritabanına kaydeder.
        // Malzemeler ve adımlar formdan tek metin olarak gelir; satırlara bölüp
        // Ingredient ve RecipeStep nesnelerine çeviriyoruz.
        [HttpPost]
        public IActionResult Create(RecipeCreateViewModel model)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
                return View(model);
            }

            var recipe = new Recipe
            {
                Title = model.Title,
                Description = model.Description,
                PrepTime = model.PrepTime.Value,
                CookTime = model.CookTime.Value,
                Servings = model.Servings.Value,
                CategoryId = model.CategoryId.Value,
                Rating = 0,
                ImageUrl = _context.Categories.Find(model.CategoryId)?.ImageUrl ?? "",
                Ingredients = model.IngredientsText
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(m => new Ingredient { Text = m.Trim() })
                    .ToList(),
                Steps = model.StepsText
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select((m, i) => new RecipeStep { StepNumber = i + 1, Text = m.Trim() })
                    .ToList()
            };

            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}