using TicektRaiseAPI.Interfaces;
using TicektRaiseAPI.Models;

namespace TicektRaiseAPI.Services
{
    public class SolutionService : ISolutionService<Solution, int>
    {
        private readonly ISolution<Solution, int> _solution;
        private readonly ITicket<Ticket, int> _ticket;

        public SolutionService(ISolution<Solution,int> solution,
                               ITicket<Ticket,int> ticket) 
        {
            _solution = solution;
            _ticket = ticket;
        }
        public async Task<Solution?> Provide(Solution item)
        {
            var checkID = await _ticket.Get(item.TicketID);
            if (checkID != null)
            {
                item.ResolvedDate = DateTime.Now;
                var addResult = await _solution.Provide(item);
                if (addResult != null)
                    return addResult;
                return null;
            }
            return null;   
        }

        //public async Task<Solution?> Delete(int key)
        //{
        //    var deleteResult = await _solution.Delete(key);
        //    if (deleteResult != null)
        //        return deleteResult;
        //    return null;
        //}

        //public async Task<Solution?> Get(int key)
        //{
        //    var solution = await _solution.Get(key);
        //    if (solution != null)
        //        return solution;
        //    return null;
        //}

        //public async Task<Solution?> Update(Solution item)
        //{
        //    var updateResult = await _solution.Update(item);
        //    if (updateResult != null)
        //        return updateResult;
        //    return null;
        //}
    }
}
