using Library1.DTO.UserRoleDtos;
using Library1.EntityModels;
using Library1.filters;
using Library1.Services.UserRoleServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library1.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRoleService _roleService;
        public UserController(IUserRoleService service)
        {
            _roleService = service;
            
        }


        [HttpPost("AddUserByRole")]


        [Authorize]
        [RoleFilter("admin")]
        public async Task<ActionResult<ServiceResponce<string>>> AddUserByRole(User_RoleDto user_Role)
        {
            return await _roleService.AddUserByRole(user_Role);

        }
    }
}
