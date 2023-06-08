using System.Security.Cryptography;
using System.Text;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILogin<LogInDTO,int,string> _login;
        private readonly IFilter<Intern> _filter;
        private readonly IGeneratePassword _generatePassword;
        private readonly IRepo<User, int> _repo;

        public LoginService(ILogin<LogInDTO,int,string> login,
                            IFilter<Intern> filter,
                            IGeneratePassword generatePassword,
                            IRepo<User,int> repo)
        {
            _login = login;
            _filter = filter;
            _generatePassword = generatePassword;
            _repo = repo;
        }
        public async Task<string> AddIn(LogInDTO logInDTO)
        {
            var result = await _login.AddIn(logInDTO);
            if (result != null)
                return "Successfull";
            return "Unsuccessfull";
        }
        public async Task<string> AddOut(LogInDTO logInDTO)
        {
            var result = await _login.AddOut(logInDTO);
            if (result != null)
                return "Successfull";
            return "Unsuccessfull";

        }

        public async Task<string> ChangePassword(PasswordDTO passwordDTO)
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
            if (result != null)
                return "Success";
            return "Failure";

        }

        public Task<ICollection<Intern>> GetAllUsers()
        {
            var result = _filter.GetAllUsers();
            if (result != null)
                return result;
            return null;

        }

        public async Task<string> UpdateStatus(int UserId, string Status)
        {
            var result = await _login.Update(UserId,Status);
            if (result != null)
                return "Successful";
            return "UnSuccessful";

        }
    }
}
