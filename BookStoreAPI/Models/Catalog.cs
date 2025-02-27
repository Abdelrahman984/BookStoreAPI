﻿namespace BookStoreAPI.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Book> Books { get; set; } = new List<Book>();

    }
}
