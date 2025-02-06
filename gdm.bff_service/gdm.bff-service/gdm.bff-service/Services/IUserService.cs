using gdm.bff_service.Models;

namespace gdm.bff_service.Services
{
    public interface IUserService
    {
        void Register(User user);
        string Authenticate(string username, string password);
    }
}
