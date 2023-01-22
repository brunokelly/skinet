using Skinet.Domain.SeedOfWork;

namespace Skinet.Application.Accounts.Services
{
    public class AccountService : IAccountService
    {
        readonly INotification _notification;

        public AccountService(INotification notification)
        {
            _notification = notification;
        }
    }
}
