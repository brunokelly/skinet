﻿using Skinet.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Accounts.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
