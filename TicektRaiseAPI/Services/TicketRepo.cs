using Microsoft.EntityFrameworkCore;
using TicektRaiseAPI.Interfaces;
using TicektRaiseAPI.Models;
using TicektRaiseAPI.Models.Context;

namespace TicektRaiseAPI.Services
{
    public class TicketRepo : ITicket<Ticket, int>
    {
        private readonly TicketContext _ticketContext;
        private readonly ILogger<TicketRepo> _logger;

        public TicketRepo(TicketContext ticketContext,
                          ILogger<TicketRepo> logger)
        {
            _ticketContext = ticketContext;
            _logger = logger;
        }
        public async Task<Ticket?> Raise(Ticket item)
        {
            try
            {
                _ticketContext.Tickets.Add(item);
                await _ticketContext.SaveChangesAsync();
                return item;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Ticket?> Cancel(int key)
        {
            var ticket = await Get(key);
            if (ticket != null)
            {
                _ticketContext.Tickets.Remove(ticket);
                await _ticketContext.SaveChangesAsync();
                return ticket;
            }
            return null;
        }

        public async Task<Ticket?> Get(int key)
        {
            var ticketDetails = await _ticketContext.Tickets.FirstOrDefaultAsync(u => u.TicketID == key);
            return ticketDetails;
        }

        public async Task<ICollection<Ticket>?> GetAll()
        {
            var tickets = await _ticketContext.Tickets.ToListAsync();
            return tickets;
        }

        //public async Task<Ticket?> Update(Ticket item)
        //{
        //    var ticket = await Get(item.TicketID);
        //    if (ticket != null)
        //    {
        //        ticket.IssueTitle = item.IssueTitle;
        //        ticket.IssueDescription = item.IssueDescription;
        //        ticket.IssueDate = item.IssueDate;
        //        await _ticketContext.SaveChangesAsync();
        //        return ticket;
        //    }
        //    return null;
        //}
    }
}
