using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface IGeneratePassword
    {
        public Task<string?> GeneratePassword(Intern intern);
    }
}
