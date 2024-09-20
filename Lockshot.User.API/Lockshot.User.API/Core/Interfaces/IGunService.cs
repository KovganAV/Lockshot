using Lockshot.User.API.Class;
using System.Threading.Tasks;

namespace Lockshot.User.API.Core.Interfaces
{
    public interface IGunService
    {
        Task<IEnumerable<Gun>> GetAllGunsAsync(int userId);
        Task<IEnumerable<Gun>> GetMostGunByCalibre(int userId, string Calibre);
        Task<IEnumerable<Gun>> GetMostGunByNameGun(int userId, string NameGun);
        Task<IEnumerable<Gun>> GetMostGunById(int userId, int Id);
        Task<IEnumerable<Gun>> GetMostGunByWeaponType(int userId, string WeaponType);
        Task<IEnumerable<Gun>> GetMostGunByFiringMode(int userId, string FiringMode);
    }
}
