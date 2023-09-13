using AutoMapper;
using Library1.DB;
using Library1.DTO.BookDtos;
using Library1.DTO.GenreDtos;
using Library1.EntityModels;
using Microsoft.EntityFrameworkCore;
using static Library1.DTO.GenreDtos.GetGenreDto;
using GenreDto = Library1.DTO.GenreDtos.GenreDto;

namespace Library1.Services.GenreServices
{
    public class GenreService : IGenre
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public GenreService(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponce<string>> CreateGenre(GenreDto genreDto)
        {
            var service = new ServiceResponce<string>();
            var old = _context.genres.FirstOrDefault(x=> x.Name == genreDto.Name);
            if (old != null)
            {
                service.Massage = "ჟანრი უკვე არსებობს";
               return service;

            }
            var grene = new Genre()
            {
                Name = genreDto.Name,

            };

            _context.genres.Add(grene);
            _context.SaveChanges();

            service.Massage = "წარმატებით შეიქმნა";
            return service;


        }

        public async  Task<ServiceResponce<string>> DeleteGenre(int id)
        {
            var service = new ServiceResponce<string>();
            var old = _context.genres.FirstOrDefault(x => x.Id == id);
            if (old == null)
            {
                service.Massage = "ჟანრი ვერ მოიძებნა";
                return service;

            }

            _context.genres.Remove(old);
            _context.SaveChanges();
            service.Massage = "წარმატებით წაიშალა";
            return service;

        }

        public async Task<ServiceResponce<List<GetGenreDto>>> GetAllGenreWithBooks()
        {
            var service = new ServiceResponce<List<GetGenreDto>>();
            var genre = await _context.genres
                .Include(x => x.GenreBook)
                .ThenInclude(x => x.Book).Select(x => new  GetGenreDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    bookDtos = x.GenreBook.Select(x=> new BookDto()
                    {
                        Name = x.Book.Name,
                        Description = x.Book.Description,
                        authorId = x.Book.authorId

                    }).ToList(),
                    
                }
                ).ToListAsync();


            service.Data = genre;
            return service;
                
        }

        public async Task<ServiceResponce<GetGenreDto>> GetGenreWithBooks(int id)
        {
            var service = new ServiceResponce<GetGenreDto>();
            var genre = await _context.genres
                .Include(x=> x.GenreBook).ThenInclude(x=> x.Book)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (genre == null)
            {
                service.Massage = "ვერ მოიძებნა";
                return service;
            }

            var genredto = new GetGenreDto()
            {
                Id = genre.Id,
                Name = genre.Name,
                bookDtos = genre.GenreBook.Select(x => new BookDto()
                {
                    Name = x.Book.Name,
                    Description = x.Book.Description,
                    authorId = x.Book.authorId

                }).ToList(),

            };
            service.Data = genredto;
            return service;
        }

        public async Task<ServiceResponce<GenreDto>> UpdateGenre(int Id, GenreDto genreDto)
        {
            var service = new ServiceResponce<GenreDto>();
            var old = _context.genres.FirstOrDefault(x => x.Id == Id);
            if (old == null)
            {
                service.Massage = "ჟანრი ვერ მოიძებნა";
                return service;

            }

            old.Name = genreDto.Name;

            _context.genres.Update(old);
            _context.SaveChanges();
            return service;



        }
    }
}
