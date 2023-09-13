namespace Library1.EntityModels
{
    public class BookGenre
    {
        public int bookId { get; set; }
        public Book Book { get; set; }
        public int GreneId { get; set; }
        public Genre Grene { get; set; }
    }
}
