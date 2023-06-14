using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace TicektRaiseAPI.Models.Context
{
    public class TicketContext:DbContext
    {
        public TicketContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Solution> Solutions { get; set; }
    }
}
