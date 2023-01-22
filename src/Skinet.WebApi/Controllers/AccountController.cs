using Microsoft.AspNetCore.Mvc;
using Skinet.Domain.SeedOfWork;

namespace Skinet.WebApi.Controllers
{
    public class AccountController : BaseController
    {
        protected AccountController(INotification notification) : base(notification)
        {
        }
    }
}
