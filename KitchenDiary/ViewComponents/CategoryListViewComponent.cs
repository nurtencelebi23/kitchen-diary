using KitchenDiary.Data;
using Microsoft.AspNetCore.Mvc;

public class CategoryListViewComponent : ViewComponent
{
    private readonly AppDbContext _context;

    public CategoryListViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        return View(_context.Categories.ToList());
    }
}