using Synaptum.Core.Domain.Entities;

namespace Synaptum.Core.Application.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(string email, string password);
        Task<string> Login(string email, string password);
    }
}