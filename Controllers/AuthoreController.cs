using Library1.DTO.AuthorDto;
using Library1.EntityModels;
using Library1.Services.AuthorServices;
using Microsoft.AspNetCore.Mvc;

namespace Library1.Controllers
{

    public class AuthoreController : ControllerBase
    {

        private readonly IAuthorService _authorService;
        public AuthoreController(IAuthorService authorService)
        {
            _authorService = authorService;
            
        }


        [HttpPost("create-author")]

        public async Task<ActionResult<ServiceResponce<string>>> CreateAuthor(AuthorDto authorDto)
        {
            return await _authorService.CreateAuthor(authorDto);    

        }


        [HttpDelete("delete-author")]

        public async Task<ActionResult<ServiceResponce<string>>> deleteAuthor(int authorId)
        {
            return await _authorService.DeleteAutor(authorId);

        }

        [HttpPut("update-author")]

        public async Task<ActionResult<ServiceResponce<AuthorDto>>> updateAuthor(int authorId, AuthorDto authorDto)
        {
            return await _authorService.UpdateAuthor(authorId, authorDto);

        }

        [HttpGet("get-author/{id}")]

        public async Task<ActionResult<ServiceResponce<GetAuthorDto>>> GetAuthorById (int id)
        {
            return await _authorService.GetaAuthorById(id);
        }

        [HttpGet("get-all-authors")]

        public async Task<ActionResult<ServiceResponce<List<GetAuthorDto>>>> GetAllAuthors()
        {
            return await _authorService.GetAllAuthor();
        }

    }
}
