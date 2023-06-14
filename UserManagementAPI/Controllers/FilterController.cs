using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class FilterController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public FilterController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Get All Users")]
        [ProducesResponseType(typeof(ICollection<Intern>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Intern>>> GetAllUsers()
        {
            var result = await _loginService.GetAllUsers();
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Get All Log Details")]
        [ProducesResponseType(typeof(ICollection<Login>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Login>>> GetAllLog()
        {
            var result = await _loginService.GetAllLog();
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }


    }
}
