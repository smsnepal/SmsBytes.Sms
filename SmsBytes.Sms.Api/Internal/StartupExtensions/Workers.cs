using Microsoft.Extensions.DependencyInjection;
using SmsBytes.Sms.Api.Internal.Workers;

namespace SmsBytes.Sms.Api.Internal.StartupExtensions
{
    public static class Workers
    {
        public static void RegisterWorker(this IServiceCollection services)
        {
            services.AddHostedService<Worker>();
        }
    }
}
