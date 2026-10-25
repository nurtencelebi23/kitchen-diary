using KitchenDiary.Models;
using KitchenDiary.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KitchenDiary.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Ana sayfada öne çıkan en yüksek puanlı 3 tarif
            var featured = _context.Recipes
                .OrderByDescending(r => r.Rating)
                .Take(3)
                .ToList();

            return View(featured);
        }

        public IActionResult About()
        {
            return View();
        }   // ← About burada bitiyor

        // Program.cs'teki UseExceptionHandler("/Home/Error") buraya yönlendirir
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }   // ← sınıf burada bitiyor
}       // ← namespace burada bitiyor