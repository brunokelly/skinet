using Microsoft.AspNetCore.Mvc;
using Skinet.Application.Accounts.Models.Request;
using Skinet.Application.Accounts.Services;
using Skinet.Domain.SeedOfWork;

namespace Skinet.WebApi.Controllers
{
    public class AccountController : BaseController
    {
        readonly IAccountService _accountService;
        public AccountController(INotification notification, IAccountService accountService) : base(notification)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            return Response(await _accountService.LoginAsync(loginRequest));
        }
    }
}
