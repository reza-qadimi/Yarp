using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;
//namespace UserManagement.RestApi.Infrastructure.Middlewares;

public static class MiddlewareExtensions : object
{
	#region Constructor(s)
	static MiddlewareExtensions()
	{
	}
	#endregion /Constructor(s)

	#region Use Jwt Middleware
	public static
		IApplicationBuilder
		UseJwtValidatorMiddleware(this IApplicationBuilder builder)
	{
		// UseMiddleware → Extension Method → using Microsoft.AspNetCore.Builder;
		var result =
			builder.UseMiddleware
			<HostService.Infrastructure.Middlewares.JwtValidatorMiddleware>();

		return result;
	}
	#endregion /Use Jwt Middleware
}
