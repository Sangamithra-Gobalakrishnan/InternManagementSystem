using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface ILoginService
    {
        public Task<LogInDTO?> AddInTime(LogInDTO logInDTO);
        public Task<LogInDTO?> AddOutTime(LogInDTO logInDTO);
        public Task<LogInDTO?> UpdateStatus(int UserId);
        public Task<ICollection<Intern>?> GetAllUsers();

        public Task<ICollection<Login>?> GetAllLog();
        public Task<User?> ChangePassword(PasswordDTO passwordDTO);

    }
}
