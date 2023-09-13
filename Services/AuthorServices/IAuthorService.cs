using Library1.DTO.AuthorDto;
using Library1.EntityModels;

namespace Library1.Services.AuthorServices
{
    public interface IAuthorService
    {
        Task<ServiceResponce<string>> CreateAuthor(AuthorDto authorDto);

        Task<ServiceResponce<AuthorDto>> UpdateAuthor( int authorID, AuthorDto authorDto);

        Task<ServiceResponce<string>> DeleteAutor(int authorID);

       Task<ServiceResponce<GetAuthorDto>> GetaAuthorById (int ID);

        Task<ServiceResponce<List<GetAuthorDto>>> GetAllAuthor();


    }
}
