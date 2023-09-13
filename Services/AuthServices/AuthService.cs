using Library1.DB;
using Library1.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Library1.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly LibraryContext _context;
        public AuthService(LibraryContext context )
        {
            _context = context;
            
        }
        public async Task<User> Login(string username, string password)
        {
            //var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            var user = await _context.users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.users.AddAsync(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.users.AnyAsync(x => x.Username == username);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
