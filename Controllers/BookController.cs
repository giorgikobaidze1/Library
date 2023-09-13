using Library1.DTO.AuthorDto;
using Library1.DTO.BookDtos;
using Library1.DTO.GenreDtos;
using Library1.EntityModels;
using Library1.Services.AuthorServices;
using Library1.Services.BookServices;
using Microsoft.AspNetCore.Mvc;

namespace Library1.Controllers
{
    public class BookController :ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;

        }
        [HttpPost ("create-book")]

        public async Task<ActionResult<ServiceResponce<string>>> CreateBook(BookDto bookDto)
        {
            return await _bookService.CreateBook(bookDto);

        }

        [HttpDelete("delete-book")]

        public async Task<ActionResult<ServiceResponce<string>>> DeleteBook(int bookId)
        {
            return await _bookService.DeleteBook(bookId);

        }

        [HttpPut("update-book")]

        public async Task<ActionResult<ServiceResponce<BookDto>>> CreateBook( int bookId, BookDto bookDto)
        {
            return await _bookService.UpdateBook(bookId, bookDto);

        }

        [HttpGet("Get-All-Book-With-Author")]

        public async Task<ActionResult<ServiceResponce<List<GetbookDto>>>> GetAllBookWithAuthor()
        {
            return await _bookService.GetAllBookWithAuthor();
        }

        [HttpGet("Get-Book-With-Author/{bookId}")]

        public async Task<ActionResult<ServiceResponce<GetbookDto>>> GetBookWithAuthor(int bookId)
        {
            return await _bookService.GetBookWithAuthor(bookId);
        }

        [HttpPost("add-book-by-genre")]

        public async Task<ActionResult<ServiceResponce<string>>> AddBookByGenre(BookGenreDto bookGenreDto)
        {
            return await _bookService.AddBookByGenre(bookGenreDto);

        }
    }
}
