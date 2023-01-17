using System;
using System.Linq;

namespace Skinet.Application.Common
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public object? Error { get; set; } = null;
    }
}