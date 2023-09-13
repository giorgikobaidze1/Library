namespace Library1.EntityModels
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BookGenre> GenreBook { get; set; }
    }
}
