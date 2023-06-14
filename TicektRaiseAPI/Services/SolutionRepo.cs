using Microsoft.EntityFrameworkCore;
using TicektRaiseAPI.Interfaces;
using TicektRaiseAPI.Models;
using TicektRaiseAPI.Models.Context;

namespace TicektRaiseAPI.Services
{
    public class SolutionRepo:ISolution<Solution,int>
    {
        private readonly TicketContext _ticketContext;
        private readonly ILogger<TicketRepo> _logger;

        public SolutionRepo(TicketContext ticketContext,
                            ILogger<TicketRepo> logger) 
        { 
            _ticketContext = ticketContext;
            _logger = logger;
        }

        public async Task<Solution?> Provide(Solution item)
        {
            try
            {
                _ticketContext.Solutions.Add(item);
                await _ticketContext.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        //public async Task<Solution?> Delete(int key)
        //{
        //    var solution = await Get(key);
        //    if (solution != null)
        //    {
        //        _ticketContext.Solutions.Remove(solution);
        //        await _ticketContext.SaveChangesAsync();
        //        return solution;
        //    }
        //    return null;
        //}

        //public async Task<Solution?> Get(int key)
        //{
        //    var solutionDetails = await _ticketContext.Solutions.FirstOrDefaultAsync(u => u.SolutionID == key);
        //    return solutionDetails;
        //}

        //public async Task<Solution?> Update(Solution item)
        //{
        //    var solution = await Get(item.SolutionID);
        //    if (solution != null)
        //    {
        //        solution.TicketID = item.TicketID;
        //        solution.IssueSolution = item.IssueSolution;
        //        solution.AdminName = item.AdminName;
        //        await _ticketContext.SaveChangesAsync();
        //        return solution;
        //    }
        //    return null;
        //}
    }
}
