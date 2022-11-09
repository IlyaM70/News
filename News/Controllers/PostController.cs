using DBCrud.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using News.Models;
using System.Globalization;

namespace News.Controllers
{

    public class PostController : Controller
    {
        private readonly NewsDbContext newsDbContext;


        public PostController(NewsDbContext newsDbContext)
        {
            this.newsDbContext = newsDbContext;

        }
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.FormAction = "AddToDb";
            ViewBag.Categories = new SelectList(newsDbContext.Categories, "Id", "Name");
            return View();
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToDb(Post post, IFormFile ImageUrl)
        {
            try
            {
                post.ImageUrl = await FileUploadHelper.Upload(ImageUrl);
            }
            catch (Exception) { }
            ModelState.Remove("Category");
            ModelState.Remove("ImageUrl");
            if (ModelState.IsValid)
            {



                post.Date = DateTime.Now;

                await newsDbContext.Posts.AddAsync(post);
                await newsDbContext.SaveChangesAsync();
                TempData["Status"] = "New post added!";





                return RedirectToAction("Index", "Home");
            }


            return RedirectToAction("Add", post);
        }


        public IActionResult Update(Post post, int id)
        {
            post.Id = id;
            ViewBag.Action = "Redact";
            ViewBag.FormAction = "UpdateInDb";
            ViewBag.Categories = new SelectList(newsDbContext.Categories, "Id", "Name");
            return View(post);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInDb(Post post, IFormFile ImageUrl)
        {
            try
            {
                post.ImageUrl = await FileUploadHelper.Upload(ImageUrl);
            }
            catch (Exception) { }
            ModelState.Remove("Category");
            ModelState.Remove("ImageUrl");
            if (ModelState.IsValid)
            {



                post.Date = DateTime.Now;

                newsDbContext.Posts.Update(post);
                await newsDbContext.SaveChangesAsync();
                TempData["Status"] = "Post redacted!";





                return RedirectToAction("Index", "Home");
            }


            return RedirectToAction("Update", post);
        }


        public async Task<IActionResult> Delete(Post post)
        {
            
                newsDbContext.Posts.Remove(post);
                await newsDbContext.SaveChangesAsync();
                TempData["Status"] = "Post deleted!";


                return RedirectToAction("Index", "Home");
            

        }

        public IActionResult Detail(string title, string content, string imageUrl, int categoryId, string date, int id)
        {
            Post post = new Post();
            post.Title = title;
            post.Content = content;
            post.ImageUrl = imageUrl;
            post.CategoryId = categoryId;
            var parsedDate = DateTime.ParseExact(date, "MM.dd.yyyy", CultureInfo.InvariantCulture);
            post.Date = parsedDate;
            post.Id = id;
            ViewBag.Categories = newsDbContext.Categories.ToList();
            return View(post);
        }
    }
}
