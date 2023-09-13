using AutoMapper;
using Library1.DB;
using Library1.DTO.AuthorDto;
using Library1.DTO.AuthorPersonalInfoDtos;
using Library1.DTO.BookDtos;
using Library1.DTO.GenreDtos;
using Library1.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Library1.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public BookService(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponce<string>> AddBookByGenre(BookGenreDto bookGenreDto)
        {
            var service = new ServiceResponce<string>();
            var old = 
               await _context
                .bookGenres
                .FirstOrDefaultAsync(x=> x.bookId == bookGenreDto.bookId && x.GreneId == bookGenreDto.GreneId);
            if (old != null)
            {
                service.Massage = "ასეთი კავშირი არსებობს";
                return service;
            }

            var x = _context.books.FirstOrDefault(x => x.Id == bookGenreDto.bookId);
            if (x == null)
            {
                service.Massage = "წიგნი ვერ მოიძებნა";
                return service;
            }
            var z = _context.genres.FirstOrDefault(x => x.Id == bookGenreDto.GreneId);
            if (z == null)
            {
                service.Massage = "ჟანრი ვერ მოიძენბა";
                return service;
            }

            var bookgenre = new BookGenre()
            {
                bookId = bookGenreDto.bookId,
                GreneId = bookGenreDto.GreneId,
            };

            _context.bookGenres.Add(bookgenre);
            _context.SaveChanges();




            service.Massage = "წარმატებით შექიმნა";
            return service;

        }

        public async Task<ServiceResponce<string>> CreateBook(BookDto bookDto)
        {
            var service = new ServiceResponce<string>();

            var oldBook = _context.books.Any(x=> x.Name == bookDto.Name);

            if (oldBook == true)
            {
                service.Data = "წინგი უკვე არსებობს";
                return service;
            }

            var author = await _context.authors.FirstOrDefaultAsync(x => x.Id == bookDto.authorId);
            

            if (author == null)
            {
                service.Data = " ავტორი არ არსებობს";
                return service;
            }

            var book = new Book()
            {
                Name = bookDto.Name,
                Description = bookDto.Description,
                authorId = bookDto.authorId

            };

            _context.books.Add(book);
            _context.SaveChanges();

            

            service.Massage = "წარმატებით შეიქმნა";

            return  service;




        }

        public async Task<ServiceResponce<string>> DeleteBook(int BookID)
        {
            var service = new ServiceResponce<string>();
            var deletebook = await _context.books.FirstOrDefaultAsync(x => x.Id == BookID);
               

            if (deletebook== null)
            {
                service.Massage = "წიგნი ვერ მოიძებნა";

                return service;

            }
           
            _context.books.Remove(deletebook);
            _context.SaveChanges();

            service.Massage = "წარმატებით წაიშალა";
            return service;
        }

        public async Task<ServiceResponce<List<GetbookDto>>> GetAllBookWithAuthor()
        {
            var books = await  _context.books.Select( x => _mapper.Map<GetbookDto>(x)).ToListAsync();

           

           foreach ( var book in books )
            {
                book.GetauthorDto = _mapper.Map<GetAuthorDto>(_context.authors.
                    FirstOrDefault(x => x.Id == book.authorId));

                book.GetauthorDto.AuthorPersonalInfoDto = _mapper.Map<AuthorPersonalInfoDto>
                    (_context.authorPersonallInfos.FirstOrDefault(x => x.AuthorId == book.GetauthorDto.Id));

            }


            var service = new ServiceResponce<List<GetbookDto>>();

            service.Data = books;
            return service;






        }

        public async Task<ServiceResponce<GetbookDto>> GetBookWithAuthor(int BookId)
        {
            var service = new ServiceResponce<GetbookDto>();

            var book = await _context.books
                .Include(x=> x.Author)
                .ThenInclude(x=>x.AuthorPersonallInfo)
                .FirstOrDefaultAsync(x => x.Id == BookId);
            if (book == null)
            {
                service.Massage = "წინგი ვერ მოიძებნა";
            }
            
            var getbook = _mapper.Map<GetbookDto>(book);
            getbook.GetauthorDto =_mapper.Map<GetAuthorDto>(book.Author);
            getbook.GetauthorDto.AuthorPersonalInfoDto = _mapper.Map<AuthorPersonalInfoDto>(book.Author.AuthorPersonallInfo);
            

            service.Data = getbook;
            return service;

            
        }

        public async Task<ServiceResponce<BookDto>> UpdateBook(int BookID, BookDto bookDto)
        {
            var service = new ServiceResponce<BookDto>();
            var updatebook = await _context.books.FirstOrDefaultAsync(x => x.Id == BookID);


            if (updatebook == null)
            {
                service.Massage = "წიგნი ვერ მოიძებნა";

                return service;

            }

            var author = await _context.authors.FirstOrDefaultAsync(x=> x.Id == bookDto.authorId);

            if (author==null)
            {
                service.Massage = "ავტორი ვერ მოიძებნა";

                return service;

            }

            updatebook.Id = BookID;
            updatebook.Author = author;
            updatebook.Description = bookDto.Description;
            updatebook.authorId = bookDto.authorId;


            _context.books.Update(updatebook);
            _context.SaveChanges();

            service.Data = bookDto;
            return service;
        }
    }
}
