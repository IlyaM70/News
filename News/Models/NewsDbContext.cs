using DBCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace News.Models
{
	public class NewsDbContext : DbContext
	{
        public NewsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
