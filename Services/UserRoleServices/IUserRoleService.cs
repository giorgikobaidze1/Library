using Library1.DTO.RoleDtos;
using Library1.DTO.UserRoleDtos;

namespace Library1.Services.UserRoleServices
{
    public interface IUserRoleService
    {
        Task<ServiceResponce<string>> AddUserByRole(User_RoleDto user_RoleDto);


        Task<ServiceResponce<UserDto>> GetUserByRole(int id);

        Task<ServiceResponce<List<UserDto>>> GetAllUserByRole();







    }
}
