using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Framework.HttpClient;

public class UserServices : object
{
	public UserServices() : base()
	{
		HttpContext =
			new Microsoft.AspNetCore.Http.HttpContextAccessor().HttpContext;
	}

	public Microsoft.AspNetCore.Http.HttpContext HttpContext { get; }


	public string Token()
	{
		string token = null;

		try
		{
			var requestHeaders =
				HttpContext.Request.Headers["Authorization"];

			token =
				requestHeaders
				.FirstOrDefault()
				?.Split(" ")
				.Last()
				;
		}
		catch (System.Exception)
		{
		}

		return token;
	}

	public int? UserId()
	{
		int? userId = null;

		try
		{
			//if (HttpContext is not null && HttpContext.Items is not null && HttpContext.Items.Any())
			//{
			//	var foundedItem =
			//		HttpContext.Items
			//		.Where(current => current.Key.ToString() == "AuthenticateUser")
			//		.FirstOrDefault();

			//	if (foundedItem.Value is not null)
			//	{
			//		var user =
			//			foundedItem.Value as dynamic;

			//		userId = user.Id;
			//	}
			//}

			//var claims =
			//	HttpContext.User.Claims;

			//if (claims != null)
			//{
			//	var currentClaim =
			//		claims
			//		.Where(current => current.Type.ToLower() == "NameIdentifier".ToLower())
			//		.FirstOrDefault();

			//	var value =
			//		currentClaim?.Value;

			//	if (value != null)
			//	{
			//		userId =
			//			System.Convert.ToInt32(value: value);
			//	}
			//}

			var token = Token();

			var handler =
				new
				System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

			var jwtSecurityToken =
				handler.ReadJwtToken(token: token);

			var value =
				jwtSecurityToken.Claims
				.Where(current => current.Type.ToString().ToLower() == "nameid")
				.FirstOrDefault()
				?.Value;

			if (value != null)
			{
				userId = System.Convert.ToInt32(value: value);
			}
		}
		catch (System.Exception)
		{
		}

		return userId;
	}

	public string UserRole()
	{
		string role = null;

		try
		{
			//if (HttpContext is not null && HttpContext.Items is not null && HttpContext.Items.Any())
			//{
			//	var foundedItem =
			//		HttpContext.Items
			//		.Where(current => current.Key.ToString() == "AuthenticateUser")
			//		.FirstOrDefault();

			//	if (foundedItem.Value is not null)
			//	{
			//		var user =
			//			foundedItem.Value as dynamic;

			//		role = user.Role;
			//	}
			//}


			var token = Token();

			var handler =
				new
				System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

			var jwtSecurityToken =
				handler.ReadJwtToken(token: token);

			role =
				jwtSecurityToken.Claims
				.Where(current => current.Type.ToString().ToLower() == "role")
				.FirstOrDefault()
				?.Value;
		}
		catch (System.Exception)
		{
		}

		return role;
	}

	public string RemoteIP()
	{
		var remoteIP = string.Empty;

		var xForwardedFor = "X-Forwarded-For";

		var localIP = "127.0.0.1";

		if (HttpContext.Request.Headers.ContainsKey(xForwardedFor))
		{
			remoteIP =
				HttpContext.Request.Headers[xForwardedFor];
		}
		else
		{
			remoteIP =
				HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
		}

		if (string.IsNullOrWhiteSpace(value: remoteIP))
		{
			remoteIP = localIP;
		}

		if (remoteIP == "::1")
		{
			remoteIP = localIP;
		}

		if (remoteIP == "localhost")
		{
			remoteIP = localIP;
		}

		return remoteIP;


	}
}
