using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamService;

        public TeamController(ITeamRepository teamService)
        {
            _teamService = teamService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(Guid id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null) return NotFound();
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] Team team)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _teamService.AddTeamAsync(team);
            return CreatedAtAction(nameof(GetTeam), new { id = team.ID }, team);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam([FromBody] Team team)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _teamService.UpdateTeamAsync(team);
            return CreatedAtAction(nameof(GetTeam), new { id = team.ID }, team);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var team = _teamService.DeleteTeamAsync(id);
            return Ok(true);
        }

    }
}
