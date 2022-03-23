using Microsoft.AspNetCore.Hosting;
using System;

namespace HelloFriendsAPI.Extensions
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder UsePort(this IWebHostBuilder builder)
        {
            var port = Environment.GetEnvironmentVariable("PORt");

            if (string.IsNullOrEmpty(port))
            {
                return builder;
            }
            return builder.UseUrls($"http://+:{port}");
        }
    }
}
