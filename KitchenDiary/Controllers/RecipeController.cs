using Microsoft.EntityFrameworkCore;
using KitchenDiary.Data;
using KitchenDiary.Models;
using Microsoft.AspNetCore.Mvc;
/* SelectList kullanmak için eklendi */
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting; // IWebHostEnvironment için eklendi
using System.IO;

namespace KitchenDiary.Controllers
{
    public class RecipeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // 1. Ortam servisi tanımlandı

        // 2. Constructor içine eklendi (Dependency Injection)
        public RecipeController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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

            try
            {
                string imageUrl = "";

                // Kullanıcı özel bir görsel yüklediyse:
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    // IWebHostEnvironment kullanarak wwwroot yolunu güvenle alıyoruz
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "recipes");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ImageFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(fileStream);
                    }

                    imageUrl = "/images/recipes/" + uniqueFileName;
                }
                else
                {
                    // Görsel yüklemediyse mevcut kategori görselini al
                    imageUrl = _context.Categories.Find(model.CategoryId)?.ImageUrl ?? "";
                }

                var recipe = new Recipe
                {
                    Title = model.Title,
                    Description = model.Description,
                    PrepTime = model.PrepTime ?? 0,
                    CookTime = model.CookTime ?? 0,
                    Servings = model.Servings ?? 1,
                    CategoryId = model.CategoryId ?? 0,
                    Rating = 0,
                    ImageUrl = imageUrl,
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
            catch (Exception ex)
            {
                ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
                ModelState.AddModelError("", "Resim kaydedilirken hata oluştu: " + ex.Message);
                return View(model);
            }
        }
    }
}