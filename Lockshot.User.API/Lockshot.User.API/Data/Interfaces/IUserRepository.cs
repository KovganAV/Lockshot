using System.Collections.Generic;
using System.Threading.Tasks;
using Lockshot.User.API.Class;

namespace Lockshot.User.API.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Lockshot.User.API.Class.User>> GetAllUsersAsync();
        Task<Lockshot.User.API.Class.User> GetUserByNameAsync(string Name);
        Task<Lockshot.User.API.Class.User> GetUserByIdAsync(int Id);
        Task<Lockshot.User.API.Class.User> CreateUserAsync(Lockshot.User.API.Class.User user);
        Task<Lockshot.User.API.Class.User> GetUserByEmailAsync(string Email);
    }
}
