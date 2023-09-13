using Library1.DTO.BookDtos;
using Library1.DTO.GenreDtos;

namespace Library1.Services.GenreServices
{
    public interface IGenre
    {
        Task<ServiceResponce<string>> CreateGenre(GenreDto genreDto);
        Task<ServiceResponce<GenreDto>> UpdateGenre(int Id, GenreDto genreDto);
        Task<ServiceResponce<string>> DeleteGenre(int id);

        Task<ServiceResponce<List<GetGenreDto>>> GetAllGenreWithBooks();

        Task<ServiceResponce<GetGenreDto>> GetGenreWithBooks(int id);
    }
}
