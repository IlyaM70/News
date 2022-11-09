using DBCrud.Models;
using News.Models;

namespace News.Helpers
{
    public static class NewsDbInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();
            var context = services.ServiceProvider.GetRequiredService<NewsDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category { Name = "Business" });
                context.Categories.Add(new Category { Name = "Politics" });
                context.Categories.Add(new Category { Name = "Technology" });
                context.Categories.Add(new Category { Name = "Fashion" });
                context.Categories.Add(new Category { Name = "Life Style" });

            }

            if (!context.Posts.Any())
            {
                for ( int i=1; i<8;i++)
                {
                    context.Posts.Add(new Post
                    {
                        Title = "Test",
                        CategoryId = 1,
                        Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live.",
                        Date = DateTime.Now,
                        ImageUrl = $"/uploads/{i}.jpg"
                    });
                }
                for (int i = 8; i < 15; i++)
                {
                    context.Posts.Add(new Post
                    {
                        Title = "Test",
                        CategoryId = 2,
                        Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live.",
                        Date = DateTime.Now,
                        ImageUrl = $"/uploads/{i}.jpg"
                    });
                }
                for (int i = 15; i < 22; i++)
                {
                    context.Posts.Add(new Post
                    {
                        Title = "Test",
                        CategoryId = 3,
                        Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live.",
                        Date = DateTime.Now,
                        ImageUrl = $"/uploads/{i}.jpg"
                    });
                }
                for (int i = 22; i < 29; i++)
                {
                    context.Posts.Add(new Post
                    {
                        Title = "Test",
                        CategoryId = 4,
                        Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live.",
                        Date = DateTime.Now,
                        ImageUrl = $"/uploads/{i}.jpg"
                    });
                }
                for (int i = 29; i < 36; i++)
                {
                    context.Posts.Add(new Post
                    {
                        Title = "Test",
                        CategoryId = 5,
                        Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live.",
                        Date = DateTime.Now,
                        ImageUrl = $"/uploads/{i}.jpg"
                    });
                }





            }



            context.SaveChanges();
        }
    }
}
