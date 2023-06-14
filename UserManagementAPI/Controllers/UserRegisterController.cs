using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class UserRegisterController : ControllerBase
    {
        private readonly IManageUser _manageUser;

        public UserRegisterController(IManageUser manageUser)
        {
            _manageUser = manageUser;
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Register(InternDTO intern)
        {
            var result = await _manageUser.Register(intern);
            if (result != null)
                return Ok(result);
            return BadRequest("Unable to register at this moment");
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Login(UserDTO userDTO)
        {
            var result = await _manageUser.Login(userDTO);
            if (result != null)
                return Ok(result);
            return BadRequest("Invalid credentials");

        }
    }
}
