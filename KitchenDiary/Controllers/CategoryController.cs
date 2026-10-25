using KitchenDiary.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitchenDiary.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        // ASP.NET, Program.cs'te kaydettiğimiz AppDbContext'i buraya kendisi verir
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }

        // /Category/Details/1
        public IActionResult Details(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            ViewBag.Category = category;

            var recipes = _context.Recipes
                .Where(r => r.CategoryId == id)
                .ToList();

            return View(recipes);
        }
    }
}