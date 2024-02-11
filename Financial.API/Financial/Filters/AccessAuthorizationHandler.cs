using Microsoft.AspNetCore.Authorization;

namespace Financial.Web.Filters
{
    public partial class Access : IAuthorizationRequirement { }

    public class AccessAuthorizationHandler : AuthorizationHandler<Access>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccessAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, Access requirement)
        {
            var httpContext = this._httpContextAccessor.HttpContext;
            var username = httpContext.Request.Headers["user"].SingleOrDefault();
            if (username == null)
            {
                var message = "You are not authorized!";
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await httpContext.Response.WriteAsync(message);
                await httpContext.Response.CompleteAsync();
                context.Fail();
            }

            context.Succeed(requirement);
        }
    }
}
