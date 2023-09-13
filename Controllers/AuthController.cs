using Library1.DB;
using Library1.DTO.GenreDtos.UserDtos;
using Library1.EntityModels;
using Library1.Services.AuthServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library1.Controllers
{
    public class AuthController :ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        private readonly LibraryContext _context;

        public AuthController(IAuthService authService, IConfiguration config, LibraryContext context)
        {
            _authService = authService;
            _config = config;
            _context = context;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _authService.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exists");



            var role = _context.roles.FirstOrDefault(x => x.Name == "Reader");
            int roleId = role != null ? role.Id : 2;

            List<UserRole> roles = new List<UserRole>();
            roles.Add(
                new UserRole()
                {
                    RoleId = roleId
                }
                );

            User userToCreate = new()
            {

                Username = userForRegisterDto.Username,
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                
           
               
            };


            var createdUser = await _authService.Register(userToCreate, userForRegisterDto.Password);

            //var userToReturn = _mapper.Map<UserForDetailedDto>(createdUser);


            //return CreatedAtRoute("GetUser", new
            //{
            //    controller = "Users",
            //    id = createdUser.Id
            //}, createdUser);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto userForLoginDto)
        {
            var userFromRepo = await _authService.Login(userForLoginDto.Username
                .ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
                
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                //Expires = DateTime.Now.AddDays(1), 
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            //var user = _mapper.Map<UserForListDto>(userFromRepo);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                userFromRepo
            });
        }

    }
}
