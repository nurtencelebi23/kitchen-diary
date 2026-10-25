using KitchenDiary.Models;
using KitchenDiary.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KitchenDiary.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Ana sayfada öne çıkan en yüksek puanlı 3 tarif
            var featured = FakeData.Recipes
                .OrderByDescending(r => r.Rating)
                .Take(3)
                .ToList();

            return View(featured);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}