﻿using Lockshot.User.API.Class;
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

        public async Task<IEnumerable<HitDto>> GetHitsByUserAsync(int userId, bool sortDescending = false)
        {
            var hits = await _hitRepository.GetHitsByUserAsync(userId, sortDescending);
            return hits.Select(hit => new HitDto
            {
                UserId = hit.UserId,
                WeaponType = hit.WeaponType,
                Score = hit.Score,
                Distance = hit.Distance,
                Metrics = hit.Metrics
            });
        }

    }
}
