var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient
	<Microsoft.AspNetCore.Http.IHttpContextAccessor,
	Microsoft.AspNetCore.Http.HttpContextAccessor>();

builder.Services.AddTransient
	<Framework.HttpClient.UserServices>();

// **************************************************
// Configure()-> using Microsoft.Extensions.DependencyInjection;
builder.Services.Configure<Jwt.Infrastructure.Settings.Main>
	(builder.Configuration.GetSection(key: Jwt.Infrastructure.Settings.Main.KeyName))
	// AddSingleton()-> using Microsoft.Extensions.DependencyInjection;
	.AddSingleton
	(implementationFactory: serviceType =>
	{
		var result =
			// GetRequiredService()-> using Microsoft.Extensions.DependencyInjection;
			serviceType.GetRequiredService
			<Microsoft.Extensions.Options.IOptions
			<Jwt.Infrastructure.Settings.Main>>().Value;

		return result;
	});
// **************************************************

// **************************************************
builder.Services
	.AddTransient
	<Jwt.Services.IUsersService,
	Jwt.Services.UsersService>();
// **************************************************

var app = builder.Build();

// Configure the HTTP request pipeline.
// **************************************************
app.UseHttpsRedirection();
// **************************************************

// **************************************************
app.UseRouting();

app.UseJwtMiddleware();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});
// **************************************************

app.Run();
