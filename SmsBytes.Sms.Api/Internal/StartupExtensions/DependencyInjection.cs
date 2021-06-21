using SmsBytes.Sms.Storage;
using Microsoft.Extensions.DependencyInjection;
using SmsBytes.Sms.Common.Uuid;

namespace SmsBytes.Sms.Api.Internal.StartupExtensions
{
    public static class DependencyInjection
    {
        public static void ConfigureRequiredDependencies(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<ApplicationContext>();
            services.AddScoped<IWeatherRepository, WeatherRepository>();
            services.AddSingleton<IUuidService, UuidService>();
        }
    }
}
