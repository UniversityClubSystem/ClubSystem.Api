using ClubSystem.Lib.Interfaces;
using ClubSystem.Lib.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClubSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        
        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        [HttpGet]
        public IActionResult GetAllClubs()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var users = _clubRepository.GetAllClubs();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetClub(string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _clubRepository.GetClub(id);

            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddClub([FromBody] Club club)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var newClub =_clubRepository.AddClub(club);
            
            return Ok(newClub);
        }
    }
}