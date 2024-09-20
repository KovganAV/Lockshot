using Lockshot.User.API.Class;
using Lockshot.User.API.Core.Interfaces;
using Lockshot.User.API.Data.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;
using Lockshot.User.API.Data.Interfaces;
using Lockshot.User.API.Core.DTOs;

namespace Lockshot.User.API.Core.Services
{
    public class GunService : IGunService
    {

        private readonly IGunRepository _gunRepository;

        public GunService(IGunRepository gunRepository)
        {
            _gunRepository = gunRepository;
        }

        public async Task<IEnumerable<Gun>> GetAllGunsAsync(int userId)
        {
            return await _gunRepository.GetAllGunsAsync(userId);
        }

        public async Task<IEnumerable<Gun>> GetMostGunByCalibre(int userId, string Calibre)
        {
            var guns = await _gunRepository.GetMostGunByCalibre(userId, Calibre);

            return guns
                .OrderByDescending(Gun => Gun.Calibre)
                .Select(Gun => new Gun
                {
                    Id = Gun.Id,
                    UserId = Gun.UserId,
                    NameGun = Gun.NameGun,
                    WeaponType = Gun.WeaponType,
                    MaxDistance = Gun.MaxDistance,
                    Bulets = Gun.Bulets,
                    FiringMode = Gun.FiringMode,
                    Calibre = Gun.Calibre
                });
        }
        public async Task<IEnumerable<Gun>> GetMostGunByNameGun(int userId, string NameGun)
        {
            var guns = await _gunRepository.GetMostGunByNameGun(userId, NameGun);

            return guns
                .OrderByDescending(Gun => Gun.NameGun)
                .Select(Gun => new Gun
                {
                    Id = Gun.Id,
                    UserId = Gun.UserId,
                    NameGun = Gun.NameGun,
                    WeaponType = Gun.WeaponType,
                    MaxDistance = Gun.MaxDistance,
                    Bulets = Gun.Bulets,
                    FiringMode = Gun.FiringMode,
                    Calibre = Gun.Calibre
                });
        }
        public async Task<IEnumerable<Gun>> GetMostGunById(int userId, int Id)
        {
            var guns = await _gunRepository.GetMostGunById(userId, Id);

            return guns
                .OrderByDescending(Gun => Gun.Id)
                .Select(Gun => new Gun
                {
                    Id = Gun.Id,
                    UserId = Gun.UserId,
                    NameGun = Gun.NameGun,
                    WeaponType = Gun.WeaponType,
                    MaxDistance = Gun.MaxDistance,
                    Bulets = Gun.Bulets,
                    FiringMode = Gun.FiringMode,
                    Calibre = Gun.Calibre
                });
        }
        public async Task<IEnumerable<Gun>> GetMostGunByWeaponType(int userId, string WeaponType)
        {
            var guns = await _gunRepository.GetMostGunByWeaponType(userId, WeaponType);

            return guns
                .OrderByDescending(Gun => Gun.WeaponType)
                .Select(Gun => new Gun
                {
                    Id = Gun.Id,
                    UserId = Gun.UserId,
                    NameGun = Gun.NameGun,
                    WeaponType = Gun.WeaponType,
                    MaxDistance = Gun.MaxDistance,
                    Bulets = Gun.Bulets,
                    FiringMode = Gun.FiringMode,
                    Calibre = Gun.Calibre
                });
        }
        public async Task<IEnumerable<Gun>> GetMostGunByFiringMode(int userId, string FiringMode)
        {
            var guns = await _gunRepository.GetMostGunByFiringMode(userId, FiringMode);

            return guns
                .OrderByDescending(Gun => Gun.FiringMode)
                .Select(Gun => new Gun
                {
                    Id = Gun.Id,
                    UserId = Gun.UserId,
                    NameGun = Gun.NameGun,
                    WeaponType = Gun.WeaponType,
                    MaxDistance = Gun.MaxDistance,
                    Bulets = Gun.Bulets,
                    FiringMode = Gun.FiringMode,
                    Calibre = Gun.Calibre
                });
        }

        public async Task<IEnumerable<Gun>> GetMostGunByBulets(int userId, int Bulets)
        {
            var guns = await _gunRepository.GetMostGunByBulets(userId, Bulets);

            return guns
                .OrderByDescending(Gun => Gun.Bulets)
                .Select(Gun => new Gun
                {
                    Id = Gun.Id,
                    UserId = Gun.UserId,
                    NameGun = Gun.NameGun,
                    WeaponType = Gun.WeaponType,
                    MaxDistance = Gun.MaxDistance,
                    Bulets = Gun.Bulets,
                    FiringMode = Gun.FiringMode,
                    Calibre = Gun.Calibre
                });
        }
    }
}

