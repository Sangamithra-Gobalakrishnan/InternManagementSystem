using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface IManageUser
    {
        public Task<UserDTO?> Login(UserDTO user);
        public Task<UserDTO?> Register(InternDTO intern);
    }
}
