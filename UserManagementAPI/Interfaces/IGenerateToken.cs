using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface IGenerateToken
    {
        public string GenerateToken(UserDTO user);
    }
}
