﻿namespace Library1.EntityModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int authorId { get; set; }
        
        public Author Author { get; set; }

        public List<BookGenre> bookGenres { get; set; }
    }
}
