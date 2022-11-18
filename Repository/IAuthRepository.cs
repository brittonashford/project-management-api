using project_management_api.Models;

namespace project_management_api.Repository
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string user, string password);
        Task<bool> UserExists(string username);
    }
}
