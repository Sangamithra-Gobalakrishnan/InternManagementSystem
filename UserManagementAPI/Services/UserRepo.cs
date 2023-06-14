using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Services
{
    public class UserRepo : IRepo<User, int>
    {
        private readonly UserContext _context;
        private readonly ILogger<UserRepo> _logger;

        public UserRepo(UserContext context, ILogger<UserRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<User?> Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<User?> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<User?> Get(int key)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == key);
            return user;
        }

        public async Task<ICollection<User>?> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User?> Update(User item)
        {
            var user = await Get(item.UserId);
            if (user != null)
            {
                user.Role = item.Role;
                user.PasswordHash = item.PasswordHash;
                user.PasswordKey = item.PasswordKey;
                user.Status = item.Status;
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }
    }
}
