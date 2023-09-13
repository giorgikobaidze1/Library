using Library1.DTO.RoleDtos;

namespace Library1.DTO.UserRoleDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public List<GetRoleDto> Roles { get; set; }

    }
}
