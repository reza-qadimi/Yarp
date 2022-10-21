using System.Linq;

namespace HostService.Infrastructure.Middlewares;

public class JwtValidatorMiddleware : object
{
	public JwtValidatorMiddleware
		(Microsoft.AspNetCore.Http.RequestDelegate next,
		HostService.Infrastructure.Settings.Application settings) : base()
	{
		Next = next;

		Settings = settings.Jwt;
	}
	protected Settings.Jwt Settings { get; }

	protected Microsoft.AspNetCore.Http.RequestDelegate Next { get; }

	public async System.Threading.Tasks.Task InvokeAsync
		(Microsoft.AspNetCore.Http.HttpContext context)
	{
		var requestHeaders =
			context.Request.Headers["Authorization"];

		var token =
			requestHeaders
			.FirstOrDefault()
			?.Split(" ")
			.Last();

		if (token != null)
		{

			var key =
				System.Text.Encoding.ASCII
				.GetBytes(s: Settings.SecretKey);

			var tokenHandler =
			new
			System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
			tokenHandler.ValidateToken
			(token: token, validationParameters: new Microsoft.IdentityModel.Tokens.TokenValidationParameters
			{
				ValidateIssuer = false,

				ValidateAudience = false,

				ValidateIssuerSigningKey = true,

				ClockSkew = System.TimeSpan.Zero,

				IssuerSigningKey =
					new
					Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key: key),

			}, validatedToken: out Microsoft.IdentityModel.Tokens.SecurityToken validateToken);

			if (validateToken is not System.IdentityModel.Tokens.Jwt.JwtSecurityToken)
			{
				throw new Exceptions.InvalidAuthenticationException();
			}
		}

		await Next(context: context);
	}
}
