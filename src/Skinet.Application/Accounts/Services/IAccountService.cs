using Skinet.Application.Accounts.Models.Request;
using Skinet.Application.Accounts.Models.Response;

namespace Skinet.Application.Accounts.Services
{
    public interface IAccountService
    {
        Task<UserResponse> LoginAsync(LoginRequest loginRequest);
    }
}
