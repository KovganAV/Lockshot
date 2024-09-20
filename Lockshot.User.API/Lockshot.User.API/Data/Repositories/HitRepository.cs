using Lockshot.User.API.Class;
using Lockshot.User.API.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lockshot.User.API.Data.Repositories
{
    public class HitRepository : IHitRepository
    {
        private readonly ApplicationDbContext _context;

        public HitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveHitAsync(Hit hit)
        {
            _context.Hits.Add(hit);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hit>> GetHitsByUserAsync(int userId, bool sortDescending = false)
        {
            var query = _context.Hits.Where(h => h.UserId == userId);


            if (sortDescending)
            {
                query = query.OrderByDescending(h => h.Score);
            }
            else
            {
                query = query.OrderBy(h => h.Score);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Hit>> GetHitsByDistance(int userId, double distance)
        {
            return await _context.Hits
                .Where(hit => hit.UserId == userId && hit.Distance == distance)
                .ToListAsync();
        }

        public async Task<IEnumerable<Hit>> GetHitsByMetrics(int userId, double Metrics)
        {
            return await _context.Hits
                .Where(hit => hit.UserId == userId && hit.Metrics == Metrics)
                .ToListAsync();
        }

        public async Task<IEnumerable<Hit>> GetHitsByScore(int userId, int Score)
        {
            return await _context.Hits
                .Where(hit => hit.UserId == userId && hit.Score == Score)
                .ToListAsync();
        }

        public async Task<IEnumerable<Hit>> GetAllHits(int userId)
        {
            return await _context.Hits
                .Where(hit => hit.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Hit>> GetHitsByWeaponType(int userId, string WeaponType)
        {
            return await _context.Hits
                .Where(hit => hit.UserId == userId && WeaponType == WeaponType)
                .ToListAsync();
        }
    }
}

