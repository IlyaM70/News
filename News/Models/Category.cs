﻿using News.Models;

namespace DBCrud.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
