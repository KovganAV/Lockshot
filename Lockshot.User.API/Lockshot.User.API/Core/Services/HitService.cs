using Lockshot.User.API.Class;
using Lockshot.User.API.Core.DTOs;
using Lockshot.User.API.Core.Interfaces;
using Lockshot.User.API.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lockshot.User.API.Core.Services
{
    public class HitService : IHitService
    {
        private readonly IHitRepository _hitRepository;

        public HitService(IHitRepository hitRepository)
        {
            _hitRepository = hitRepository;
        }

        public async Task SaveHitAsync(HitDto hitDto)
        {
            var hit = new Hit
            {
                UserId = hitDto.UserId,
                WeaponType = hitDto.WeaponType,
                Score = hitDto.Score,
                Distance = hitDto.Distance,
                Timestamp = DateTime.UtcNow
            };
            
            await _hitRepository.SaveHitAsync(hit);
        }

        public async Task<IEnumerable<HitDto>> GetMostHitsByMetrics(int userId, double Metrics)
        {
            var hits = await _hitRepository.GetHitsByMetrics(userId, Metrics);

            return hits
                .OrderByDescending(hit => hit.Metrics) 
                .Select(hit => new HitDto
                {
                    Id = hit.Id,
                    WeaponType = hit.WeaponType,
                    Score = hit.Score,
                    Timestamp = hit.Timestamp,
                    Distance = hit.Distance,
                    Metrics = hit.Metrics
                });
        }

        public async Task<IEnumerable<HitDto>> GetMostByDistance(int userId, double Distance)
        {
            var hits = await _hitRepository.GetHitsByDistance(userId, Distance);

            return hits
                .OrderByDescending(hit => hit.Score)
                .Select(hit => new HitDto
                {
                    Id = hit.Id,
                    WeaponType = hit.WeaponType,
                    Score = hit.Score,
                    Timestamp = hit.Timestamp,
                    Distance = hit.Distance,
                    Metrics = hit.Metrics
                });
        }
        public async Task<IEnumerable<HitDto>> GetMostHitsByScore(int userId, int Score)
        {
            var hits = await _hitRepository.GetHitsByScore(userId, Score);

            return hits
                .OrderByDescending(hit => hit.Score)
                .Select(hit => new HitDto
                {
                    Id = hit.Id,
                    WeaponType = hit.WeaponType,
                    Score = hit.Score,
                    Timestamp = hit.Timestamp,
                    Distance = hit.Distance,
                    Metrics = hit.Metrics
                });
        }

        public async Task<IEnumerable<HitDto>> GetHitsByWeaponType(int userId, string WeaponType)
        {
            var hits = await _hitRepository.GetHitsByWeaponType(userId, WeaponType);

            return hits
                .OrderByDescending(hit => hit.WeaponType)
                .Select(hit => new HitDto
                {
                    Id = hit.Id,
                    WeaponType = hit.WeaponType,
                    Score = hit.Score,
                    Timestamp = hit.Timestamp,
                    Distance = hit.Distance,
                    Metrics = hit.Metrics
                });
        }

        public async Task<IEnumerable<HitDto>> GetAllHits(int userId)
        {
            var hits = await _hitRepository.GetAllHits(userId);
            return hits.Select(hit => new HitDto
            {
                Id = hit.Id,
                WeaponType = hit.WeaponType,
                Score = hit.Score,
                Timestamp = hit.Timestamp,
                Distance = hit.Distance,
                Metrics = hit.Metrics
            });
        }
    }
}
