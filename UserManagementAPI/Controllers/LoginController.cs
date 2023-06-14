using Microsoft.AspNetCore.Authorization;
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
        [ProducesResponseType(typeof(LogInDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LogInDTO>> LogInTime (LogInDTO logInDTO)
        {
            var result = await _loginService.AddInTime(logInDTO);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("LogOut Time")]
        [ProducesResponseType(typeof(LogInDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> LogOutTime(LogInDTO logInDTO)
        {
            var result = await _loginService.AddOutTime(logInDTO);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update Status")]
        [ProducesResponseType(typeof(LogInDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LogInDTO?>> UpdateStatus(int UserID)
        {
            var result = await _loginService.UpdateStatus(UserID);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("Change Password")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User?>> ChangePassword(PasswordDTO passwordDTO)
        {
            var result = await _loginService.ChangePassword(passwordDTO);
            if (result != null)
                return Ok(result);
            return BadRequest("Unable To Change Password at this moment");
        }

    }
}
