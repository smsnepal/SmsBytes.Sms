using System;
using Micro.GraphQL.Federation;
using SmsBytes.Sms.Api.GraphQL.Directives;
using SmsBytes.Sms.Api.GraphQL.Types;

namespace SmsBytes.Sms.Api.GraphQL
{
    public class StarterSchema : Schema<EntityType>
    {
        public StarterSchema(IServiceProvider services, Query query) : base(services)
        {
            Query = query;
            Directives.Register(new AuthorizeDirective());
            RegisterVisitor(typeof(AuthorizeDirectiveVisitor));
        }
    }
}
