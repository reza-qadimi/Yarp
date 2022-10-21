using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient
	<Microsoft.AspNetCore.Http.IHttpContextAccessor,
	Microsoft.AspNetCore.Http.HttpContextAccessor>();

builder.Services.AddTransient
	<Framework.HttpClient.UserServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// **************************************************
app.UseHttpsRedirection();
// **************************************************

// **************************************************
app.UseRouting();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});
// **************************************************

app.Run();
