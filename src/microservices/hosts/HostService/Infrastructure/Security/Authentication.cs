using Microsoft.Extensions.Configuration;
using HostService.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace HostService.Infrastructure.Security;

public static class Authentication : object
{
	static Authentication()
	{
	}

	public static void AddAuthorizationPolicies
		(this IServiceCollection services,
		ConfigurationManager configuration)
	{
		var configs =
			new ConfigurationBuilder()
			.AddYmlFile("appsettings.yml", optional: false, reloadOnChange: true)
			.Build();

		var settings =
			new Settings.Application();

		configs.Bind
			(key: Settings.Application.KeyName, instance: settings);

		foreach (var item in settings.Policies)
		{
			var roleRequirement =
				new
				RoleRequirement
				(roles: item.ValidRoles, isAuthenticated: item.IsAuthenticated);

			services.AddAuthorization(options =>
			{
				options.AddPolicy(item.Name, policy =>
				{
					policy.AddRequirements(requirements: roleRequirement);
				});
			});
		}
	}

	public static void AddAuthentication
		(this IServiceCollection services,
		ConfigurationManager configuration,
		Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents? events = null)
	{
		var authenticationConfig =
			configuration.GetSection("Authentication") ??
			throw new System.ArgumentException("Authentication section is missing!");

		services.AddAuthentication()
		.AddCookie(options =>
		{
			//options.LoginPath = "/Account/Unauthorized/";
			//options.AccessDeniedPath = "/Account/Forbidden/";
		})
		.AddJwtBearer(options =>
		{
			//options.Audience = "http://localhost:5001/";
			//options.Authority = "http://localhost:5000/";
		})
		;


		services.AddAuthentication(options =>
		{
			options.DefaultScheme =
				Microsoft.AspNetCore.Authentication.JwtBearer
				.JwtBearerDefaults.AuthenticationScheme;

			//.Cookies
			//.CookieAuthenticationDefaults.AuthenticationScheme;

			//options.DefaultChallengeScheme =
			//	Microsoft.AspNetCore.Authentication.OpenIdConnect
			//	.OpenIdConnectDefaults.AuthenticationScheme;

			//options.DefaultSignOutScheme =
			//	Microsoft.AspNetCore.Authentication.OpenIdConnect
			//	.OpenIdConnectDefaults.AuthenticationScheme;
		});
		//.AddCookie(Microsoft.AspNetCore.Authentication.Cookies
		//.CookieAuthenticationDefaults.AuthenticationScheme, options =>
		//{
		//	options.Cookie.HttpOnly = false;
		//	//options.Cookie.Name = authenticationConfig["CookieName"] ?? "__BFF";
		//	options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
		//	options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
		//}).AddJwtBearer(option => { });

		//.AddOpenIdConnect
		//(Microsoft.AspNetCore.Authentication.OpenIdConnect
		//.OpenIdConnectDefaults.AuthenticationScheme, options =>
		//{
		//	// Bind OIDC authentication configuration
		//	configuration.GetSection("Authentication").Bind(options);

		//	options.Events = events;

		//	// Add dynamically scope values from configuration
		//	var scopes =
		//		configuration.GetSection("Authentication")["Scope"]
		//		.Split(" ")
		//		.ToList();

		//	options.Scope.Clear();

		//	scopes.ForEach(scope => options.Scope.Add(scope));

		//	options.TokenValidationParameters = new()
		//	{
		//		NameClaimType = "Name",
		//		RoleClaimType = "Role",
		//	};
		//});
	}
}

//public class TokenAuthenticationHandler :
//	Microsoft.AspNetCore.Authentication.AuthenticationHandler<TokenAuthenticationHandler>
//{
//	public System.IServiceProvider ServiceProvider { get; set; }

//	public TokenAuthenticationHandler
//		(Microsoft.Extensions.Options.IOptionsMonitor<Settings.Main> options,
//		Microsoft.Extensions.Logging.ILoggerFactory logger,
//		System.Text.Encodings.Web.UrlEncoder encoder,
//		Microsoft.AspNetCore.Authentication.ISystemClock clock,
//		System.IServiceProvider serviceProvider)
//		: base(options, logger, encoder, clock)
//	{
//		ServiceProvider = serviceProvider;
//	}

//	protected override
//		System.Threading.Tasks.Task<Microsoft.AspNetCore.Authentication.AuthenticateResult>
//		HandleAuthenticateAsync()
//	{
//		var headers = Request.Headers;
//		//var token = "X-Auth-Token".GetHeaderOrCookieValue(Request);
//		var token =
//			new Framework.HttpClient.UserServices()
//			.Token()
//			;


//		if (string.IsNullOrEmpty(token))
//		{
//			return System.Threading.Tasks.Task.FromResult
//				(Microsoft.AspNetCore.Authentication.AuthenticateResult.Fail("Token is null"));
//		}

//		bool isValidToken = false; // check token here

//		if (!isValidToken)
//		{
//			return System.Threading.Tasks.Task.FromResult
//				(Microsoft.AspNetCore.Authentication.AuthenticateResult.Fail
//				($"Balancer not authorize token : for token={token}"));
//		}

//		var claims = new[] { new System.Security.Claims.Claim("token", token) };
//		var identity = new System.Security.Claims.ClaimsIdentity(claims, nameof(TokenAuthenticationHandler));
//		var ticket = new Microsoft.AspNetCore.Authentication.AuthenticationTicket(new System.Security.Claims.ClaimsPrincipal(identity), this.Scheme.Name);
//		return System.Threading.Tasks.Task.FromResult(Microsoft.AspNetCore.Authentication.AuthenticateResult.Success(ticket));
//	}
//}
