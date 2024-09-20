using Lockshot.User.API.Class;
using Lockshot.User.API.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lockshot.User.API.Data.Repositories
{
    public class GunRepository : IGunRepository
    {
        private readonly ApplicationDbContext _context;

        public GunRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Gun>> GetAllGunsAsync(int UserId)
        {
        
            return await _context.Guns
                .Where(gun => gun.UserId == UserId)
                .ToListAsync();
        
        }

        public async Task<IEnumerable<Gun>> GetMostGunByCalibre(int userId, string Calibre)
        {
            return await _context.Guns
                .Where(gun => gun.Calibre == Calibre)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gun>> GetMostGunByNameGun(int userId, string NameGun)
        {
            return await _context.Guns
                .Where(gun => gun.NameGun == NameGun)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gun>> GetMostGunById(int userId, int Id)
        {
            return await _context.Guns
                .Where(gun => gun.Id == Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gun>> GetMostGunByWeaponType(int userId, string WeaponType)
        {
            return await _context.Guns
                .Where(gun => gun.WeaponType == WeaponType)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gun>> GetMostGunByFiringMode(int userId, string FiringMode)
        {
            return await _context.Guns
                .Where(gun => gun.FiringMode == FiringMode)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gun>> GetMostGunByBulets(int userId, int Bulets)
        {
            return await _context.Guns
                .Where(gun => gun.Bulets == Bulets)
                .ToListAsync();
        }
    }
}
