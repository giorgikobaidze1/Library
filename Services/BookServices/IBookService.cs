using Library1.DTO.AuthorDto;
using Library1.DTO.BookDtos;
using Library1.DTO.GenreDtos;

namespace Library1.Services.BookServices
{
    public interface IBookService
    {
        Task<ServiceResponce<string>> CreateBook(BookDto bookDto);
        Task<ServiceResponce<BookDto>> UpdateBook(int BookID, BookDto bookDto);
        Task<ServiceResponce<string>> DeleteBook(int BookID);

        Task<ServiceResponce<List<GetbookDto>>> GetAllBookWithAuthor();
        Task<ServiceResponce<GetbookDto>> GetBookWithAuthor(int BookId);

        Task<ServiceResponce<string>> AddBookByGenre(BookGenreDto bookGenreDto);
    }
}
