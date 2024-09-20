using Lockshot.User.API.Core.DTOs;
using Lockshot.User.API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lockshot.User.API.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HitsController : ControllerBase
    {
        private readonly IHitService _hitService;

        public HitsController(IHitService hitService)
        {
            _hitService = hitService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveHit(HitDto hitDto)
        {
            await _hitService.SaveHitAsync(hitDto);
            return Ok();
        }

        [HttpGet("{userId}/all")]
        public async Task<IActionResult> GetAllHits(int userId)
        {
            var hits = await _hitService.GetAllHits(userId);

            if (hits == null || !hits.Any())
            {
                return NotFound("No hits found for the specified user and distance.");
            }

            return Ok(hits);
        }

        [HttpGet("{userId}/{Distance}/distance")]
        public async Task<IActionResult> GetMostHitsByDistance(int userId, double Distance)
        {
            var hits = await _hitService.GetMostByDistance(userId, Distance);

            if (hits == null || !hits.Any())
            {
                return NotFound("No hits found for the specified user and distance.");
            }

            return Ok(hits);
        }

        [HttpGet("{userId}/{Metrics}/metrics")]

        public async Task<IActionResult> GetMostHitsByMetrics(int userId, double Metrics)
        {
            var hits = await _hitService.GetMostHitsByMetrics(userId, Metrics);

            if (hits == null || !hits.Any())
            {
                return NotFound("No hits found for the specified user and Metrics.");
            }

            return Ok(hits);
        }

        [HttpGet("{userId}/{Score}/score")]
        public async Task<IActionResult> GetMostHitsByScore(int userId, int Score)
        {
            var hits = await _hitService.GetMostHitsByScore(userId, Score);

            if (hits == null || !hits.Any())
            {
                return NotFound("No hits found for the specified user and Score.");
            }

            return Ok(hits);
        }


        [HttpGet("{userId}/{WeaponType}/weapon type")]
        public async Task<IActionResult> GetHitsByWeaponType(int userId, string WeaponType)
        {
            var hits = await _hitService.GetHitsByWeaponType(userId, WeaponType);

            if (hits == null || !hits.Any())
            {
                return NotFound("No hits found for the specified user and Weapon Type.");
            }

            return Ok(hits);
        }
    }
}
