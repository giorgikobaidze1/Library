using Library1.DTO.RoleDtos;
using Library1.Services.RoleServices;
using Microsoft.AspNetCore.Mvc;

namespace Library1.Controllers
{
    public class RoleController :ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
            
        }


        [HttpPost("create-role")]

        public async Task <ActionResult<ServiceResponce<string>>> CreateRole (RoleDto roleDto)
        {
            return await _roleService.CreateRole(roleDto);
        }

        [HttpPut("update-role")]

        public async Task<ActionResult<ServiceResponce<GetRoleDto>>> UpdateRole(GetRoleDto roleDto)
        {
            return await _roleService.UpdateRole(roleDto);
        }

        [HttpDelete("Delete-role")]

        public async Task<ActionResult<ServiceResponce<string>>> DeleteRole(int ID)
        {
            return await _roleService.DeleteRole(ID);
        }

        [HttpPut("Get-all-role")]

        public async Task<ActionResult<ServiceResponce<List<GetRoleDto>>>> GetAllRole()
        {
            return await _roleService.GetAllRole();
        }
    }
}
