using Skinet.Application.Accounts.Models.Request;
using Skinet.Application.Accounts.Models.Response;
using Skinet.Domain.Identity;
using System.Security.Claims;

namespace Skinet.Application.Accounts.Services
{
    public interface IAccountService
    {
        Task<UserResponse> LoginAsync(LoginRequest loginRequest);
        Task<UserResponse> RegisterUserAsync(RegisterRequest registerRequest);
        Task<UserResponse> GetCurrentUserAsync(ClaimsPrincipal user);
        Task<bool> CheckIfEmailExistsAsync(string email);
        Task<AddressResponse> GetUserAddressAsync(ClaimsPrincipal user);
        Task<AddressResponse> UpdateUserAddressAsync(ClaimsPrincipal user, AddressRequest address);
    }
}
