using System.Linq;

namespace HostService.Infrastructure.Security;

public class RoleRequirement :
	Microsoft.AspNetCore.Authorization.AuthorizationHandler<RoleRequirement>,
	Microsoft.AspNetCore.Authorization.IAuthorizationRequirement
{
	public RoleRequirement
		(bool isAuthenticated, System.Collections.Generic.IList<string> roles)
	{
		Roles = roles;
		IsAuthenticated = isAuthenticated;
	}

	private bool IsAuthenticated { get; set; }

	public System.Collections.Generic.IList<string> Roles { get; }

	protected override async
		System.Threading.Tasks.Task HandleRequirementAsync
		(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext context, RoleRequirement requirement)
	{
		if (IsAuthenticated == false)
		{
			context.Succeed(requirement);
		}
		else
		{
			var role =
				new
				Framework.HttpClient.UserServices().UserRole();

			if (string.IsNullOrWhiteSpace(value: role) == false)
			{
				if (Roles == null || Roles.Any() == false)
				{
					context.Succeed(requirement);
				}
				else if (Roles.Where(current => current.ToLower().Trim() == role.ToLower().Trim()).Any())
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

		await System.Threading.Tasks.Task.CompletedTask;
	}
}
