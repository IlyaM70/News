using Microsoft.AspNetCore.Mvc;
using News.Models;

namespace News.Controllers
{
	public class CategoryController : Controller
	{
        private readonly NewsDbContext newsDbContext;

        public CategoryController(NewsDbContext newsDbContext)
        {
           this.newsDbContext = newsDbContext;
        }

        public IActionResult Category(int categoryId)
		{
            ViewBag.Categories = newsDbContext.Categories.ToList();
            var posts = newsDbContext.Posts.Where(p => p.CategoryId == categoryId).ToList();
            return View(posts);
		}
	}
}
