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
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("LogIn Time")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> LogInTime (LogInDTO logInDTO)
        {
            var result = await _loginService.AddIn(logInDTO);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("LogOut Time")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> LogOutTime(LogInDTO logInDTO)
        {
            var result = await _loginService.AddOut(logInDTO);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update Status")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> UpdateStatus(int UserID,string Status)
        {
            var result = await _loginService.UpdateStatus(UserID, Status);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpPut("Change Password")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> ChangePassword(PasswordDTO passwordDTO)
        {
            var result = await _loginService.ChangePassword(passwordDTO);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
