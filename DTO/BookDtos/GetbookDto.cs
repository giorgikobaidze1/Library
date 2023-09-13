using Library1.DTO.AuthorDto;

namespace Library1.DTO.BookDtos
{
    public class GetbookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int authorId { get; set; }
        public GetAuthorDto GetauthorDto { get; set; }

    }
}
