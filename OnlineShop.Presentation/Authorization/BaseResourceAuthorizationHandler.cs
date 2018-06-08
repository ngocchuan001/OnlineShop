using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using OnlineShop.Application.Interfaces;
using OnlineShop.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop.Presentation.Authorization
{
    public class BaseResourceAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, string>
    {
        private readonly IAppRoleService _roleService;

        public BaseResourceAuthorizationHandler(IAppRoleService roleService)
        {
            _roleService = roleService;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, string resource)
        {
            var roles = ((ClaimsIdentity)context.User.Identity).Claims.FirstOrDefault(x => x.Type == CommonConstants.UserClaims.Roles);
            if (roles != null)
            {
                var listRole = roles.Value.Split(";");
                var hasPermission = await _roleService.CheckPermission(resource, requirement.Name, listRole);
                if (hasPermission || listRole.Contains(CommonConstants.AppRole.AdminRole))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
            else
            {
                context.Fail();
            }
        }
    }
}
