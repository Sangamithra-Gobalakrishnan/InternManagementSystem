using UserManagementAPI.Interfaces;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILogin<LogInDTO> _login;

        public LoginService(ILogin<LogInDTO> login)
        {
            _login = login; 
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
    }
}
