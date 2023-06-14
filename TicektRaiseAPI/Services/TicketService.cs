using TicektRaiseAPI.Interfaces;
using TicektRaiseAPI.Models;

namespace TicektRaiseAPI.Services
{
    public class TicketService : IService<Ticket, int>
    {
        private readonly ITicket<Ticket, int> _ticket;

        public TicketService(ITicket<Ticket,int> ticket)
        {
            _ticket = ticket;
        }
        public async Task<Ticket?> Raise(Ticket item)
        {
             item.IssueDate = DateTime.Now;
             item.TicketStatus = "Not Solved";
             var addResult = await _ticket.Raise(item);
             if (addResult != null)
                return addResult;
             return null;
        }

        public async Task<Ticket?> Cancel(int key)
        {
            var deleteResult = await _ticket.Cancel(key);
            if(deleteResult != null) 
                return deleteResult;
            return null;
        }

        public async Task<Ticket?> Get(int key)
        {
            var ticket = await _ticket.Get(key);
            if (ticket != null) 
                return ticket;
            return null;
        }

        public async Task<ICollection<Ticket>?> GetAll()
        {
            var ticketDetails = await _ticket.GetAll();
            if (ticketDetails.Count() > 0)
                return ticketDetails;
            return null;
        }

        //public async Task<Ticket?> Update(Ticket item)
        //{
        //    var updateResult = await _ticket.Update(item);
        //    if (updateResult != null)
        //        return updateResult;
        //    return null;
        //}
    }
}
