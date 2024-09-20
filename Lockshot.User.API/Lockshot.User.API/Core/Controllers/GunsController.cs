using Lockshot.User.API.Class;
using Lockshot.User.API.Core.DTOs;
using Lockshot.User.API.Core.Interfaces;
using Lockshot.User.API.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lockshot.User.API.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GunsController : ControllerBase
    {
        private readonly IGunService _gunService;

        public GunsController(IGunService gunService)
        {
            _gunService = gunService;
        }
        [HttpGet("{userId}/all")]
        public async Task<IActionResult> GetAllGunsAsync(int userId)
        {
            var guns = await _gunService.GetAllGunsAsync(userId);

            if (guns == null || !guns.Any())
            {
                return NotFound("No guns");
            }

            return Ok(guns);
        }
        [HttpGet("{userId}/{Calibre}/calibre")]
        public async Task<IActionResult> GetMostGunByCalibre(int userId, string Calibre)
        {
            var guns = await _gunService.GetMostGunByCalibre(userId, Calibre);

            if (guns == null || !guns.Any())
            {
                return NotFound("No hits found for the specified user and Calibre.");
            }

            return Ok(guns);
        }

        [HttpGet("{userId}/{NameGun}/name gun")]
        public async Task<IActionResult> GetMostGunByNameGun(int userId, string NameGun)
        {
            var guns = await _gunService.GetMostGunByNameGun(userId, NameGun);

            if (guns == null || !guns.Any())
            {
                return NotFound("No hits found for the specified user and gun.");
            }

            return Ok(guns);
        }

        [HttpGet("{userId}/{Id}/id")]
        public async Task<IActionResult> GetMostGunById(int userId, int Id)
        {
            var guns = await _gunService.GetMostGunById(userId, Id);

            if (guns == null || !guns.Any())
            {
                return NotFound("No hits found for the specified user and id.");
            }

            return Ok(guns);
        }

        [HttpGet("{userId}/{WeaponType}/weapon type")]
        public async Task<IActionResult> GetMostGunByWeaponType(int userId, string WeaponType)
        {
            var guns = await _gunService.GetMostGunByWeaponType(userId, WeaponType);

            if (guns == null || !guns.Any())
            {
                return NotFound("No hits found for the specified user and weapon type.");
            }

            return Ok(guns);
        }

        [HttpGet("{userId}/{FiringMode}/miring mode")]
        public async Task<IEnumerable<Gun>> GetMostGunByFiringMode(int userId, string FiringMode)
        {
            var guns = await _gunService.GetMostGunByFiringMode(userId, FiringMode);

            if (guns == null || !guns.Any())
            {
                return (IEnumerable<Gun>)NotFound("No hits found for the specified user and miring mode.");
            }

            return (IEnumerable<Gun>)Ok(guns);
        }
    }
}