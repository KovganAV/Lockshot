using Lockshot.User.API.Class;
using Lockshot.User.API.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lockshot.User.API.Core.Interfaces
{
    public interface IHitService
    {
        Task SaveHitAsync(HitDto hitDto);
        Task<IEnumerable<HitDto>> GetMostByDistance(int userId, double Distance);
        Task<IEnumerable<HitDto>> GetMostHitsByMetrics(int userId, double Metrics);
        Task<IEnumerable<HitDto>> GetMostHitsByScore(int userId, int Score);
        Task<IEnumerable<HitDto>> GetHitsByWeaponType(int userId, string WeaponType);
        Task<IEnumerable<HitDto>> GetAllHits(int userId);
    }
}
