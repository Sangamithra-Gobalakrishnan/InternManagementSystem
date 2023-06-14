using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicektRaiseAPI.Interfaces;
using TicektRaiseAPI.Models;

namespace TicektRaiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        private readonly ISolutionService<Solution, int> _solutionService;

        public SolutionController(ISolutionService<Solution,int> solutionService)
        {
            _solutionService = solutionService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Provide Solution")]
        [ProducesResponseType(typeof(Solution), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Solution>> ProvideSolution(Solution solution)
        {
            var result = await _solutionService.Provide(solution);
            if (result != null)
                return Ok(result);
            return BadRequest("Cannot update solution at this moment");
        }

    }
}
