using KitchenDiary.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitchenDiary.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(FakeData.Categories);
        }
    }
}