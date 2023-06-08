using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Services
{
    public class ManageUserService : IManageUser
    {
        private readonly IRepo<User,int> _userRepo;
        private readonly IRepo<Intern,int> _internRepo;
        private readonly IGeneratePassword _passwordService;
        private readonly IGenerateToken _tokenService;

        public ManageUserService(IRepo<User,int> userRepo,
            IRepo<Intern, int> internRepo,
            IGeneratePassword passwordService,
            IGenerateToken tokenService)
        {
            _userRepo = userRepo;
            _internRepo = internRepo;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }
        public Task<UserDTO> ChangeStatus(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> Login(UserDTO userDTO)
        {
            UserDTO user = null;
            var userData = await _userRepo.Get(userDTO.UserId);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.PasswordHash[i])
                        return null;
                }
                user = new UserDTO();
                user.UserId = userData.UserId;
                user.Role = userData.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;

        }

        public async Task<UserDTO> Register(InternDTO intern)
        {
            UserDTO user = null;
            var userDetails = await _internRepo.GetAll();
            if (userDetails != null)
            {
                foreach(var item in userDetails)
                {
                    if(item.Name == intern.Name)
                    {
                        return null;
                    }
                }
            }
            var gender = intern.Gender;
            if(gender.ToLower() == "male" || gender.ToLower() == "female")
            {
                intern.Gender = gender.ToLower();
                var hmac = new HMACSHA512();
                string? generatedPassword = await _passwordService.GeneratePassword(intern);
                intern.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(generatedPassword ?? "1234"));
                intern.User.PasswordKey = hmac.Key;
                //intern.User.Role = "Intern";
                var userResult = await _userRepo.Add(intern.User);
                var internResult = await _internRepo.Add(intern);
                if (userResult != null && internResult != null)
                {
                    user = new UserDTO();
                    user.UserId = internResult.Id;
                    user.Role = userResult.Role;
                    user.Token = _tokenService.GenerateToken(user);
                }
                return user;
            }return null;
           
        }
    }
}
