using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using News.Models;
using System.Diagnostics;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewsDbContext newsDbContext;

        public HomeController(ILogger<HomeController> logger, NewsDbContext newsDbContext)
        {
            _logger = logger;
            this.newsDbContext = newsDbContext;
        }

        public IActionResult Index()
        {
            var categories = newsDbContext.Categories.ToList();
            ViewBag.Categories = categories;
            return View(newsDbContext.Posts.ToList());
        }

    }
}