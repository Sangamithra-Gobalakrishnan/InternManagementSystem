using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<string>> GetAllUsers()
        {
            var result = await _loginService.GetAllUsers();
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
