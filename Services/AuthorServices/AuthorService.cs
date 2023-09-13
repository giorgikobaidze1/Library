using AutoMapper;
using Library1.DB;
using Library1.DTO.AuthorDto;
using Library1.DTO.AuthorPersonalInfoDtos;
using Library1.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Library1.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public AuthorService(LibraryContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }
        public async Task<ServiceResponce<string>> CreateAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            author.AuthorPersonallInfo = _mapper.Map<AuthorPersonallInfo>(authorDto.AuthorPersonalInfoDto);

            _context.authors.Add(author);
            _context.authorPersonallInfos.Add(author.AuthorPersonallInfo);
            _context.SaveChanges();

            var service = new ServiceResponce<string>();

            service.Massage = "ავტორი წარმატებით შეიქმნა";

            return service;
        }

        public async Task<ServiceResponce<string>> DeleteAutor(int authorID)
        {
            var service = new ServiceResponce<string>();
            var deleteauthor = await _context.authors.FirstOrDefaultAsync(x => x.Id == authorID);

            if (deleteauthor == null)
            {
                service.Massage = "ავტორი ვერ მოიძებნა";

                return service;

            }
           var authorPersonalinfo = await _context.authorPersonallInfos.FirstOrDefaultAsync(x => x.AuthorId == deleteauthor.Id);

            _context.authors.Remove(deleteauthor);
            _context.authorPersonallInfos.Remove(authorPersonalinfo);
            _context.SaveChanges();

            service.Massage = "წარმატებით წაიშალა";
            return service;
        }

        public async Task<ServiceResponce<GetAuthorDto>> GetaAuthorById(int ID)
        {
            var service = new ServiceResponce<GetAuthorDto>();
            var Author = await _context.authors.Include(x=> x.AuthorPersonallInfo) 
                .FirstOrDefaultAsync(X=> X.Id == ID && X.AuthorPersonallInfo.AuthorId == ID  );

            if (Author == null)
            {
                service.Massage = "ავტორი ვერ მოიძებნა";
                return service;

            }

            var getauthor = _mapper.Map<GetAuthorDto>(Author);
            getauthor.AuthorPersonalInfoDto = _mapper.Map<AuthorPersonalInfoDto>(Author.AuthorPersonallInfo);

             service.Data = getauthor;
            return service;
           


        }

        public async Task<ServiceResponce<List<GetAuthorDto>>> GetAllAuthor()
        {
            var author = await _context.authors
                .Select(x => _mapper.Map<GetAuthorDto>(x)
            ).ToListAsync();

            foreach(var info in author)
            {
                info.AuthorPersonalInfoDto =  _mapper.Map<AuthorPersonalInfoDto>(_context.authorPersonallInfos
                    .FirstOrDefault(x=> x.AuthorId == info.Id));



            }


            

            

            
            var service = new ServiceResponce<List<GetAuthorDto>>();

            service.Data = author;
            return service; 

        }

        public async Task<ServiceResponce<AuthorDto>> UpdateAuthor(int authorID, AuthorDto authorDto)
        {
            var service = new ServiceResponce<AuthorDto>();
            var UpdateAuthor = await _context.authors.FirstOrDefaultAsync(x => x.Id == authorID );
            var info = await _context.authorPersonallInfos.FirstOrDefaultAsync(x => x.AuthorId == authorID);

            if (UpdateAuthor == null && info == null)
            {
                service.Massage = "ვერ მოიძებნა ავტორი";
                return service;
            }



           UpdateAuthor.FirsName = authorDto.FirsName;
           UpdateAuthor.LastName = authorDto.LastName;
           info.Description = authorDto.AuthorPersonalInfoDto.Description;
           

            _context.authors.Update(UpdateAuthor);
            _context.authorPersonallInfos.Update(UpdateAuthor.AuthorPersonallInfo);
            _context.SaveChanges();

            service.Data = authorDto;
            return service;



        }
    }
}
