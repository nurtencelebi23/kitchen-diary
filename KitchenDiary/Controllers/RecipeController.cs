using KitchenDiary.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}