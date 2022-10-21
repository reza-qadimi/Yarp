namespace Jwt.Infrastructure.Attributes;

[System.AttributeUsage
	(validOn: System.AttributeTargets.Method | System.AttributeTargets.Class)]
public class AuthorizeAttribute :
	System.Attribute, Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
{
	#region Constructor(s)
	public AuthorizeAttribute(string? roles = null) : base()
	{
		Roles = roles;
	}
	#endregion /Constructor(s)

	#region Property(ies)
	protected string? Roles { get; }
	#endregion /Property(ies)

	#region On Authorization
	public void OnAuthorization
		(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext context)
	{
		bool isValid = true;

		var user =
			context.HttpContext.Items[Constants.Shared.User]
			as UserManagement.Domain.Users.User;

		if ((user is not null) && (string.IsNullOrWhiteSpace(value: Roles) is false))
		{
			isValid =
				Roles.ToLower()
				.Contains(value: user.Role.ToString().ToLower());
		}

		if ((user is null) || (isValid is false))
		{
			context.Result =
				new Microsoft.AspNetCore.Mvc.JsonResult(new { message = Constants.Shared.Unauthorized })
				{
					StatusCode =
						Microsoft.AspNetCore.Http.StatusCodes
						.Status401Unauthorized,
				};
		}
	}
	#endregion /On Authorization
}
