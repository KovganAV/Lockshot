using Lockshot.User.API.Class;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lockshot.User.API.Data.Interfaces
{
    public interface IHitRepository
    {
        Task SaveHitAsync(Hit hit);
        Task<IEnumerable<Hit>> GetHitsByUserAsync(int userId, bool sortDescending = false);
        Task<IEnumerable<Hit>> GetAllHits(int userId);
        Task<IEnumerable<Hit>> GetHitsByScore(int userId, int Score);
        Task<IEnumerable<Hit>> GetHitsByMetrics(int userId, double Metrics);
        Task<IEnumerable<Hit>> GetHitsByWeaponType(int userId, string WeaponType);
        Task<IEnumerable<Hit>> GetHitsByDistance(int userId, double Distance);
    }
}
