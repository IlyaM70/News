using DBCrud.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace News.Models
{
	public class Post
	{
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Image: ")]
        public string ImageUrl { get; set; }
        

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }
        public DateTime Date { get; set; }

        
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        
    }
}
