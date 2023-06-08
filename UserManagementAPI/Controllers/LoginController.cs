using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService<Login> _loginService;

        public LoginController(ILoginService<Login> loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("LogIn Time")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> LogInTime (LogInDTO logInDTO)
        {
            var result = await _loginService.Add(logInDTO);
            if (result != null)
                return Ok(result);
            return BadRequest("Unable to register at this moment");
        }
    }
}
