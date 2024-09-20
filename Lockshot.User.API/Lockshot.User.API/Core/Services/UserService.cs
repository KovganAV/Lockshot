using Lockshot.User.API.Class;
using Lockshot.User.API.Core.Interfaces;
using Lockshot.User.API.Data.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;

namespace Lockshot.User.API.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Lockshot.User.API.Class.User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }


        public async Task<Lockshot.User.API.Class.User> GetUserByNameAsync(string Name)  
        {
            return await _userRepository.GetUserByNameAsync(Name);
        }

        public async Task<Lockshot.User.API.Class.User> RegisterAsync(RegisterUserDto registerUserDto)
        {
            var salt = GenerateSalt();
            var passwordHash = HashPassword(registerUserDto.Password, salt);
            var user = new Lockshot.User.API.Class.User
            {
                Name = registerUserDto.Name,
                Email = registerUserDto.Email,
                PasswordHash = passwordHash,
                Role = registerUserDto.Role
            };

            return await _userRepository.CreateUserAsync(user);
        }

        public async Task<Lockshot.User.API.Class.User> GetUserByIdAsync(int Id)
        {
            return await _userRepository.GetUserByIdAsync(Id);
        }

        public async Task<string> LoginAsync(LoginUserDto loginUserDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginUserDto.Email);
            if (user == null || !VerifyPassword(loginUserDto.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            return "JWT_TOKEN";
        }

        public async Task<Lockshot.User.API.Class.User> GetUserByEmailAsync(string Email)
        {
            {
                return await _userRepository.GetUserByEmailAsync(Email);
            }
        }

        private string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        private string HashPassword(string password, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{salt}:{hashed}";
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split(':');
            if (parts.Length != 2)
            {
                return false;
            }

            var salt = parts[0];
            var hash = parts[1];
            var computedHash = HashPassword(password, salt);

            return storedHash == computedHash;
        }
    }
}
