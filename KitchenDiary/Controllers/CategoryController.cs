using KitchenDiary.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitchenDiary.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View(FakeData.Categories);
        }

        // /Category/Details/1
        public IActionResult Details(int id)
        {
            var category = FakeData.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            ViewBag.Category = category;

            var recipes = FakeData.Recipes
                .Where(r => r.CategoryId == id)
                .ToList();

            return View(recipes);
        }
    }
}