using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Skinet.Application.Accounts.Models.Request;
using Skinet.Application.Accounts.Models.Response;
using Skinet.Application.Accounts.Services.Token;
using Skinet.Domain.Identity;
using Skinet.Domain.SeedOfWork;
using Skinet.Infra.Utils;
using Skinet.Infra.Utils.Extensions;
using System.Security.Claims;

namespace Skinet.Application.Accounts.Services
{
    public class AccountService : IAccountService
    {
        readonly IConfiguration _configuration;
        readonly INotification _notification;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenService _tokenService;

        public AccountService(IConfiguration configuration, INotification notification,
                UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _configuration = configuration;
            _notification = notification;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        #region USER
        public async Task<UserResponse> GetCurrentUserAsync(ClaimsPrincipal user)
        {
            var email = await _userManager.FindByEmailFromClaimsPrincipal(user);
            var currentUser = await VerifyEmail(email?.Email);

            if (currentUser is null)
            {
                _notification.AddNotification("Email", "Unauthorized Access", NotificationModel.ENotificationType.Unauthorized);
                return null;
            }

            return new UserResponse
            {
                Email = currentUser.Email,
                DisplayName = currentUser.DisplayName,
                Token = CreateToken(currentUser),
            };
        }

        public async Task<bool> CheckIfEmailExistsAsync(string email)
        {
            return await VerifyEmail(email) is not null;
        }

        public async Task<AddressResponse> GetUserAddressAsync(ClaimsPrincipal user)
        {
            var currentUser = await _userManager.FindByEmailWithAddressAsync(user);

            if (currentUser is null)
            {
                _notification.AddNotification("Address", "There is no address", NotificationModel.ENotificationType.Default);
                return null;
            }

            return (AddressResponse)currentUser.Address;
        }

        public async Task<AddressResponse> UpdateUserAddressAsync(ClaimsPrincipal user, AddressRequest address)
        {
            var currentUser = await _userManager.FindByEmailWithAddressAsync(user);
            var newAddress = new Address(address.FirstName, address.LastName, address.Street, address.City, address.State, address.ZipCode);
            currentUser.AddUserAddress(newAddress);

            var result = await _userManager.UpdateAsync(currentUser);

            if(!result.Succeeded)
            {
                GetErrorResponseFromIdentityResult(result);
                return new AddressResponse();
            }

            return (AddressResponse)currentUser.Address;
        }

        #endregion

        #region LOGIN
        public async Task<UserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await VerifyUser(loginRequest);

            if (user is null)
            {
                return new UserResponse();
            }
            
            var userResponse = new UserResponse()
            {
                Email = user.Email,
                Token = CreateToken(user),
                DisplayName = user.DisplayName
            };

            var userToLogin = await VerifyEmail(userResponse.Email);

            //var teste = await _signInManager.PasswordSignInAsync(userToLogin, loginRequest.Password, false, false);

            return userResponse;
        }

        private async Task<AppUser> VerifyUser(LoginRequest loginRequest)
        {
            var user = await VerifyEmail(loginRequest.Email);

            if (user is null || !await CheckPassword(user, loginRequest))
            {
                _notification.AddNotification("EmailOrPassword", "Unauthorized Access", NotificationModel.ENotificationType.Unauthorized);
                return null;
            };

            return user;
        }

        private async Task<AppUser> VerifyEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        private async Task<bool> CheckPassword(AppUser user, LoginRequest loginRequest)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);

            return result is null ? false : result.Succeeded;
        }
        #endregion

        #region REGISTER
        public async Task<UserResponse> RegisterUserAsync(RegisterRequest registerRequest)
        {
            var user = new AppUser(registerRequest.DisplayName, registerRequest.Email, registerRequest.Email);
            var result = await _userManager.CreateAsync(user, registerRequest.Password);

            if (!result.Succeeded)
            {
                GetErrorResponseFromIdentityResult(result);

                return new UserResponse();
            }

            return new UserResponse
            {
                DisplayName = user.DisplayName,
                Token = CreateToken(user),
                Email = user.Email,
            };
        }

        #endregion

        #region TOKEN 
        private string CreateToken(AppUser user)
        {
            return _tokenService.CreateToken(user);
        }
        #endregion

        private void GetErrorResponseFromIdentityResult(IdentityResult result)
        {
            if (result is null || result.Errors.Count() == 0) return;

            result.Errors.ToList().ForEach(erro =>
            {
                _notification.AddNotification(erro.Code, erro.Description, NotificationModel.ENotificationType.BadRequestError);
            });
        }
    }
}
