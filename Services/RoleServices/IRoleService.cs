using Library1.DTO.RoleDtos;

namespace Library1.Services.RoleServices
{
    public interface IRoleService
    {
        Task<ServiceResponce<string>> CreateRole (RoleDto roleDto);
        Task<ServiceResponce<GetRoleDto>> UpdateRole (GetRoleDto roleDto);
        Task <ServiceResponce<string>>  DeleteRole (int ID);

        Task<ServiceResponce<List<GetRoleDto>>> GetAllRole();
    }
}
