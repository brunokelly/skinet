namespace Skinet.WebApi.Middleware
{
    public class ApiException
    {
        public ApiException(int statusCode)
        {
            StatusCode = statusCode;
        }

        public ApiException(int statusCode, string message, string? stackTrace)
        {
            StatusCode = statusCode;
            Message = message;
            StackTrace = stackTrace ?? "";
        }

        public int StatusCode { get; set; }
        public string Message { get; set; } = "";
        public string StackTrace { get; set; } = "";
    }
}
