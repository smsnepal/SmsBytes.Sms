using System.Threading.Tasks;
using Micro.GraphQL.Federation;
using SmsBytes.Sms.Storage;
using SmsBytes.Sms.Api.GraphQL.Types;

namespace SmsBytes.Sms.Api.GraphQL
{
    public sealed class Query : Query<EntityType>
    {
        public Query()
        {
            Field<WeatherType, Weather>()
                .Name("weather")
                .ResolveAsync(x => Task.FromResult(new Weather
                {
                    Id = "id",
                    Temperature = 23.3
                }));
        }
    }
}
