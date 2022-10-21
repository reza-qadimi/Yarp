using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using HostService.Infrastructure.Security;

// **************************************************
var builder =
	Microsoft.AspNetCore.Builder
	.WebApplication.CreateBuilder(args: args);
// **************************************************

// **************************************************
// Add services to the container.
// **************************************************

builder.Services.AddTransient
	<Framework.HttpClient.UserServices>();

builder.Services.AddTransient
	<Microsoft.AspNetCore.Http.IHttpContextAccessor,
	Microsoft.AspNetCore.Http.HttpContextAccessor>();

// Add the reverse proxy to capability to the server
// Initialize the reverse proxy from the "ReverseProxy" section of configuration
// **************************************************
builder.Configuration.AddYmlFile
	(path: "appsettings.yml", optional: true, reloadOnChange: true);

var proxyBuilder =
	builder.Services.AddReverseProxy();

var proxyConfiguration =
	builder.Configuration.GetSection(key: "ReverseProxy");

proxyBuilder
	.LoadFromConfig(config: proxyConfiguration)
	//.AddTransforms(context =>
	//{
	//	context.RequestTransforms.Add
	//	(item: context.Services.GetRequiredService<T>());
	//})
	;
// **************************************************

builder.Services.AddAuthentication
	(configuration: builder.Configuration);

builder.Services.AddAuthorizationPolicies
	(configuration: builder.Configuration);

// **************************************************
// Configure()-> using Microsoft.Extensions.DependencyInjection;
builder.Services.Configure<HostService.Infrastructure.Settings.Application>
	(builder.Configuration.GetSection(key: HostService.Infrastructure.Settings.Application.KeyName))
	// AddSingleton()-> using Microsoft.Extensions.DependencyInjection;
	.AddSingleton
	(implementationFactory: serviceType =>
	{
		var result =
			// GetRequiredService()-> using Microsoft.Extensions.DependencyInjection;
			serviceType.GetRequiredService
			<Microsoft.Extensions.Options.IOptions
			<HostService.Infrastructure.Settings.Application>>().Value;

		return result;
	});
// **************************************************

var app = builder.Build();

// Configure the HTTP request pipeline.
// **************************************************
app.UseHttpsRedirection();

app.UseRouting();

app.UseJwtValidatorMiddleware();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapReverseProxy();
});
// **************************************************

app.Run();
