using Skinet.Application.Common;
using Skinet.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Accounts.Models.Response
{
    public class UserResponse : BaseResponse
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }

        public static implicit operator UserResponse(AppUser appUser)
        {
            if (appUser is null) return new UserResponse();

            return new UserResponse
            {
                Email = appUser.Email,
                DisplayName = appUser.DisplayName
            };
        }
    }
}
