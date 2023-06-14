using System.Security.Cryptography;
using System.Text;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILogin<LogInDTO,int> _login;
        private readonly IFilter<Intern,Login> _filter;
        private readonly IGeneratePassword _generatePassword;
        private readonly IRepo<User, int> _repo;

        public LoginService(ILogin<LogInDTO,int> login,
                            IFilter<Intern,Login> filter,
                            IGeneratePassword generatePassword,
                            IRepo<User,int> repo)
        {
            _login = login;
            _filter = filter;
            _generatePassword = generatePassword;
            _repo = repo;
        }
        public async Task<LogInDTO?> AddInTime(LogInDTO logInDTO)
        {
            var result = await _login.AddInTime(logInDTO);
            if (result != null)
                return logInDTO;
            return null;
        }
        public async Task<LogInDTO?> AddOutTime(LogInDTO logInDTO)
        {
            var result = await _login.AddOutTime(logInDTO);
            if (result != null)
                return logInDTO;
            return null;

        }
        public async Task<User?> ChangePassword(PasswordDTO passwordDTO)
        {
            User user = new User();
            var hmac = new HMACSHA512();
            var userIntern = await _repo.Get(passwordDTO.UserID);
            user.UserId = passwordDTO.UserID;
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordDTO.Password ?? "1234"));
            user.PasswordKey = hmac.Key;
            user.Status =  userIntern.Status;
            user.Role=userIntern.Role;
            var result = await _repo.Update(user);
            User resUser = new User();
            resUser.UserId = passwordDTO.UserID;
            resUser.Role = userIntern.Role;
            if (result != null)
                return resUser;
            return null;
        }

        public Task<ICollection<Intern>?> GetAllUsers()
        {
            var result = _filter.GetAllUsers();
            if (result != null)
                return result;
            return null;

        }

        public Task<ICollection<Login>?> GetAllLog()
        {
            var result = _filter.GetAllLog();
            if (result != null)
                return result;
            return null;

        }
        public async Task<LogInDTO?> UpdateStatus(int UserId)
        {
            var result = await _login.UpdateStatus(UserId);
            if (result != null)
            {
                LogInDTO logInDTO = new LogInDTO();
                logInDTO.UserId = UserId;
                return logInDTO;
            }
            return null;
        }
    }
}
