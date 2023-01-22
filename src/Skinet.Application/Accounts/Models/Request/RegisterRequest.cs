using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Accounts.Models.Request
{
    public class RegisterRequest
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }    
        public string Password { get; set; }
    }
}
