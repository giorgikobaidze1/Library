using Library1.DB;
using Library1.DTO.UserRoleDtos;
using Library1.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Library1.Services.UserRoleServices
{
    public class UserRoleService : IUserRoleService
    {
        private readonly LibraryContext _context;
        public UserRoleService(LibraryContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponce<string>> AddUserByRole(User_RoleDto user_RoleDto)
        {
            var service = new ServiceResponce<string>();
            var userrole = await _context.userRoles.FirstOrDefaultAsync(x=> x.RoleId == user_RoleDto.RoleId && x.UserId == user_RoleDto.UserId);

            if (userrole != null)
            {
                service.Massage = "ასეთი კავშირი არსებობს";

                return service;
            }

            var Users = await _context.users.FirstOrDefaultAsync(x => x.Id == user_RoleDto.UserId);
            if (Users == null)
            {
                service.Massage = "იუზერი არ არსებობს";
                return service;
            }

            var role = await _context.roles.FirstOrDefaultAsync( x => x.Id == user_RoleDto.RoleId);

            if (role == null)
            {
                service.Massage = "როლი არ არსებობს";
                return service;
            }

            var x = new UserRole()
            {
                UserId = user_RoleDto.UserId,
                RoleId = user_RoleDto.RoleId
            };

            _context.userRoles.Add(x);
            _context.SaveChanges();

            service.Massage = "წარმატებით შეიქმნა";
            return service;



        }

        public Task<ServiceResponce<List<UserDto>>> GetAllUserByRole()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponce<UserDto>> GetUserByRole(int id)
        {
            throw new NotImplementedException();
        }
    }
}
