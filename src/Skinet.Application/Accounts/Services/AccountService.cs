using Microsoft.AspNetCore.Identity;
using Skinet.Application.Accounts.Models.Request;
using Skinet.Application.Accounts.Models.Response;
using Skinet.Domain.Identity;
using Skinet.Domain.SeedOfWork;

namespace Skinet.Application.Accounts.Services
{
    public class AccountService : IAccountService
    {
        readonly INotification _notification;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        public AccountService(INotification notification, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _notification = notification;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await VerifyUser(loginRequest);

            if (user is null)
            {
                return new UserResponse();
            }

            return new UserResponse()
            {
                Email = user.Email,
                Token = "toekn",
                DisplayName = user.DisplayName
            };
        }

        private async Task<AppUser> VerifyUser(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user is null || !await CheckPassword(user, loginRequest))
            {
                _notification.AddNotification("EmailOrPassword", "Unauthorized Access", NotificationModel.ENotificationType.Unauthorized);
                return null;
            };

            return user;
        }

        private async Task<bool> CheckPassword(AppUser user, LoginRequest loginRequest)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);

            return result is null ? false : result.Succeeded;
        }
    }
}
