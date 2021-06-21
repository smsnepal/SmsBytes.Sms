namespace SmsBytes.Sms.Api.GraphQL.Types
{
    public class EntityType : Micro.GraphQL.Federation.Types.EntityType
    {
        public EntityType()
        {
            Type<WeatherType>();
        }
    }
}
