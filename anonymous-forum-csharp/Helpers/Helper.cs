namespace anonymous_forum_csharp.Helpers
{
    public class Helper
    {
        public static string GetIp(HttpContext httpContext)
        {
            string? ip = httpContext.Connection.RemoteIpAddress?.ToString();
            return ip;
        }
    }
}
