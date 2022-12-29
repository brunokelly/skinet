using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.Application.Common
{
     public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public object? Error { get; set; } = null;
    }
}