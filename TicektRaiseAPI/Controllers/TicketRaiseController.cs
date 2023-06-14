using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using TicektRaiseAPI.Interfaces;
using TicektRaiseAPI.Models;

namespace TicektRaiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class TicketRaiseController : ControllerBase
    {
        private readonly IService<Ticket, int> _service;

        public TicketRaiseController(IService<Ticket,int> service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("Raise Ticket")]
        [ProducesResponseType(typeof(Ticket), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ticket>> RaiseTicket(Ticket ticket)
        {
            var result = await _service.Raise(ticket);
            if (result != null)
                return Ok(result);
            return BadRequest("Unable to raise ticket at this moment");
        }

        [Authorize]
        [HttpDelete("Cancel Ticket")]
        [ProducesResponseType(typeof(Ticket), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ticket>> CancelTicket(int TicketID)
        {
            var result = await _service.Cancel(TicketID);
            if (result != null)
                return Ok(result);
            return BadRequest("Unable to cancel ticket at this moment");
        }

        [Authorize]
        [HttpGet("Available Ticket Details")]
        [ProducesResponseType(typeof(Ticket), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ticket>> GetAllTickets()
        {
            var result = await _service.GetAll();
            if (result != null)
                return Ok(result);
            return BadRequest("No tickets right now");
        }
    }
}
