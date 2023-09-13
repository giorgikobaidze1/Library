namespace Library1.EntityModels
{
    public class Author
    {
        public int Id { get; set; }

        public string FirsName { get; set; }

        public string LastName { get; set; }

        //public int AuthorPersonalInfoId { get; set; }

        public AuthorPersonallInfo AuthorPersonallInfo { get; set; }

        public List<Book> Books { get; set; }
    }
}
