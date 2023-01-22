using Skinet.Domain.SeedOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Common
{
    public abstract class BaseService
    {
        private readonly INotification _notification;

        public BaseService(INotification notification)
        {
            _notification = notification;
        }
    }
}
