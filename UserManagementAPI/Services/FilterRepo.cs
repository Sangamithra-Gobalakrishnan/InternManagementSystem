using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public class FilterRepo : IFilter<Intern>
    {
        private readonly UserContext _userContext;

        public FilterRepo(UserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task<ICollection<Intern>?> GetAllUsers()
        {
            var getUsers = await _userContext.Interns.Include(i => i.User).Where(o => o.User.Role == "User").ToListAsync();
            return getUsers;
        }
    }
}
