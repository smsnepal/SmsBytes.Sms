using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.AspNetCore.Http;
using SmsBytes.Sms.Api.GraphQL.Directives.Exceptions;

namespace SmsBytes.Sms.Api.GraphQL.Directives
{
    public class AuthorizeDirective : DirectiveGraphType
    {
        public const string DirectiveName = "authorize";
        public override bool? Introspectable => true;

        public AuthorizeDirective() : base(
            DirectiveName,
            DirectiveLocation.Field,
            DirectiveLocation.Mutation,
            DirectiveLocation.Query,
            DirectiveLocation.FieldDefinition)
        {
        }
    }
    public class AuthorizeDirectiveVisitor : BaseSchemaNodeVisitor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthorizeDirectiveVisitor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public override void VisitObjectFieldDefinition(FieldType field, IObjectGraphType type, ISchema schema)
        {
            var applied = field.FindAppliedDirective(AuthorizeDirective.DirectiveName);
            if (applied == null)
            {
                return;
            }

            var isAuthenticated = _contextAccessor.HttpContext?.User.Identity?.IsAuthenticated;
            if (isAuthenticated == true)
            {
                return;
            }

            field.Resolver = new AsyncFieldResolver<object>(async context => { throw new NotAuthorizedException(); });
        }
    }
}
