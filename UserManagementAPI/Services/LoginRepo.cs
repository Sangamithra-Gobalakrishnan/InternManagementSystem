using System.Reflection.Metadata.Ecma335;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Services
{
    public class LoginRepo : ILogin<LogInDTO>
    {
        private readonly UserContext _userContext;
        private readonly ILogger<LoginRepo> _logger;

        public LoginRepo(UserContext userContext, ILogger<LoginRepo> logger)
        {
            _userContext = userContext;
            _logger = logger;

        }
        public async Task<LogInDTO?> AddIn(LogInDTO item)
        {
            try
            {
                var idCheck = _userContext.Users.FirstOrDefault(i=> i.UserId == item.UserId);
                var userCheck = _userContext.LoginDetails.FirstOrDefault(i=> i.UserId == item.UserId);
                if (idCheck != null && userCheck == null)
                {
                    Login login = new Login();
                    login.UserId = item.UserId;
                    login.LogInTime = DateTime.Now;
                    _userContext.LoginDetails.Add(login);
                    await _userContext.SaveChangesAsync();
                    return item;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
        public async Task<LogInDTO?> AddOut(LogInDTO item)
        {
            try
            {
                var userCheck = _userContext.LoginDetails.FirstOrDefault(i => i.UserId == item.UserId);
                if (userCheck != null )
                {
                    userCheck.LogOutTime = DateTime.Now;
                    await _userContext.SaveChangesAsync();
                    return item;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public Task<string?> Update(int userID,string Status)
        {
            try
            {
                var userCheck = _userContext.Users.FirstOrDefault(i => i.UserId == userID);
                if (userCheck != null)
                {
                    userCheck.Status = Status;

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
    }
}
