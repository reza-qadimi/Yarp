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
		UseJwtMiddleware(this IApplicationBuilder builder)
	{
		// UseMiddleware → Extension Method → using Microsoft.AspNetCore.Builder;
		var result =
			builder.UseMiddleware
			<Jwt.Infrastructure.Middlewares.JwtMiddleware>();

		return result;
	}
	#endregion /Use Jwt Middleware
}
