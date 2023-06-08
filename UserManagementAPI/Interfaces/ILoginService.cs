using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface ILoginService
    {
        public Task<string> AddIn(LogInDTO logInDTO);
        public Task<string> AddOut(LogInDTO logInDTO);
    }
}
