using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface ILoginService
    {
        public Task<string> AddIn(LogInDTO logInDTO);
        public Task<string> AddOut(LogInDTO logInDTO);
        public Task<string> UpdateStatus(int UserId,string Status);
        public Task<ICollection<Intern>> GetAllUsers();
        public Task<string> ChangePassword(PasswordDTO passwordDTO);

    }
}
