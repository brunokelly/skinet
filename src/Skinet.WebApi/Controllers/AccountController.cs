using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skinet.Application.Accounts.Models.Request;
using Skinet.Application.Accounts.Services;
using Skinet.Domain.SeedOfWork;
using System.Security.Claims;

namespace Skinet.WebApi.Controllers
{
    public class AccountController : BaseController
    {
        readonly IAccountService _accountService;
        public AccountController(INotification notification, IAccountService accountService) : base(notification)
        {
            _accountService = accountService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            return Response(await _accountService.GetCurrentUserAsync(User));
        }

        [Authorize]
        [HttpGet("email")]
        public async Task<IActionResult> VerifyUserEmail([FromQuery] string email)
        {
            return Response(await _accountService.CheckIfEmailExistsAsync(email));
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<IActionResult> GetUserAddress()
        {
            return Response(await _accountService.GetUserAddressAsync(User));
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<IActionResult> UpdateUserAddress(AddressRequest addressRequest)
        {
            return Response(await _accountService.UpdateUserAddressAsync(User, addressRequest));
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            return Response(await _accountService.LoginAsync(loginRequest));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            return Response(await _accountService.RegisterUserAsync(registerRequest));
        }
    }
}
