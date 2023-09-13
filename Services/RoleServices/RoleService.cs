using Library1.DB;
using Library1.DTO.RoleDtos;
using Library1.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Library1.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly LibraryContext _context;
        public RoleService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponce<string>> CreateRole(RoleDto roleDto)
        {
            var service = new ServiceResponce<string>();
            var role = await _context.roles.FirstOrDefaultAsync(x=> x.Name == roleDto.RoLeName);
            if (role != null)
            {
                service.Massage = "ასეთი როლი არსებობს";
               return service;
            }

            var newRole = new Role()
            {
                Name = roleDto.RoLeName,
            };

            _context.roles.Add(newRole);
            _context.SaveChanges();

            service.Massage = "წარმატებით შეიქმნა";
            return service;

            
        }

        public async Task<ServiceResponce<string>> DeleteRole(int ID)
        {
            var service = new ServiceResponce<string>();
            var role = await _context.roles.FirstOrDefaultAsync(x => x.Id == ID);
            if (role == null)
            {
                service.Massage = " როლი ვერ მოიძებნა";
                return service;
            }

            _context.roles.Remove(role);    
            _context.SaveChanges();

            service.Massage = "წარმატებით წაიშალა";
            return service;
        }

        public async Task<ServiceResponce<List<GetRoleDto>>> GetAllRole()
        {
            var role = await _context.roles.Select(x => new GetRoleDto()
            {
                Id = x.Id,
                RoLeName = x.Name,

            }).ToListAsync();

            var service = new ServiceResponce<List<GetRoleDto>>();
            service.Data = role;
            return service;
        }

        public async Task<ServiceResponce<GetRoleDto>> UpdateRole(GetRoleDto roleDto)
        {
            var service = new ServiceResponce<GetRoleDto>();
            var role = await _context.roles.FirstOrDefaultAsync(x => x.Id == roleDto.Id);
            if (role == null)
            {
                service.Massage = " როლი ვერ მოიძებნა";
                return service;
            }

            var roleNmae = await _context.roles.FirstOrDefaultAsync(x=> x.Name == roleDto.RoLeName);
            if (roleNmae != null)
            {
                service.Massage = " როლი უკვე არსებობს";
                return service;

            }

            _context.roles.Update(role);
            _context.SaveChanges();

            service.Data = roleDto;
            return service;
        }
    }
}
