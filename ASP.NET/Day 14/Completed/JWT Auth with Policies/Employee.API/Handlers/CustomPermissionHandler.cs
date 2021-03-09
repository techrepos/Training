using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Employee.API.Handlers
{
    public class CustomPermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (requirement.PermissionName.Equals("Read") && IsUser(context.User, context.Resource))
                context.Succeed(requirement);
            else if ((requirement.PermissionName.Equals("Read") || requirement.PermissionName.Equals("Delete")
                || requirement.PermissionName.Equals("Update") || requirement.PermissionName.Equals("Add") || requirement.PermissionName.Equals("Exclusive"))
                && IsOwner(context.User, context.Resource))
                context.Succeed(requirement);
            else
                context.Fail();

            return Task.CompletedTask;
        }

        private bool IsOwner(ClaimsPrincipal user, object resource) => user.Identity.Name.Equals("amal") ? true : false;

        private bool IsUser(ClaimsPrincipal user, object resource) => (user.Identity.Name.Equals("amal") || user.Identity.Name.Equals("dev")) ? true : false;
    }
}
