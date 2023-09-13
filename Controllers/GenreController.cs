using Library1.DTO.GenreDtos;
using Library1.EntityModels;
using Library1.Services.GenreServices;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom.Compiler;

namespace Library1.Controllers
{
    public class GenreController : ControllerBase
    {
        private readonly IGenre _bookGenre;
        public GenreController(IGenre bookGenre) 
        { 
            _bookGenre = bookGenre;
        }

        [HttpPost("create-genre")]
        public async Task<ActionResult<ServiceResponce<string>>> CreateGenre(GenreDto  genre)
        {
            return await _bookGenre.CreateGenre(genre);

        }

        [HttpDelete("delete-genre")]
        public async Task<ActionResult<ServiceResponce<string>>> DeleteGenre( int id)
        {
            return await _bookGenre.DeleteGenre(id);

        }

        [HttpPut("update-genre")]
        public async Task<ActionResult<ServiceResponce<GenreDto>>> UpdateGenre(int id, GenreDto genreDto)
        {
            return await _bookGenre.UpdateGenre(id, genreDto);

        }

        [HttpGet ("GetAllGenreWithBooks")]
        public async Task<ActionResult<ServiceResponce<List<GetGenreDto>>>> GetAllGenreWithBook()
        {
            return await _bookGenre.GetAllGenreWithBooks();
        }

        [HttpGet("GetGenreWithBooks")]
        public async Task<ActionResult<ServiceResponce<GetGenreDto>>> GetGenreWithBook(int id)
        {
            return await _bookGenre.GetGenreWithBooks(id);
        }






    }
}
