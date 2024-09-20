using System.Collections.Generic;
using System.Threading.Tasks;
using Lockshot.User.API.Class;

namespace Lockshot.User.API.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<Lockshot.User.API.Class.User>> GetAllUsersAsync();
        Task<Lockshot.User.API.Class.User> GetUserByNameAsync(string name);
        Task<Lockshot.User.API.Class.User> GetUserByIdAsync(int Id);
        Task<Lockshot.User.API.Class.User> GetUserByEmailAsync(string Email);
        Task<Lockshot.User.API.Class.User> RegisterAsync(RegisterUserDto registerUserDto);
        Task<string> LoginAsync(LoginUserDto loginUserDto);
    }
}