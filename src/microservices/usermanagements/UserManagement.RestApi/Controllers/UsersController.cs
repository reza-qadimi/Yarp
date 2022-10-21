namespace UserManagement.RestApi.Controllers;

public class UsersController : Framework.Modules.ControllerBase
{
	public UsersController(Jwt.Services.IUsersService usersService) : base()
	{
		UserService = usersService;
	}

	private Jwt.Services.IUsersService UserService { get; }

	[Microsoft.AspNetCore.Mvc.HttpPost(template: "login")]
	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.ActionResult
		<ViewModels.Users.LoginResponseViewModel>>
		LoginAsync
		([Microsoft.AspNetCore.Mvc.FromBody]
		ViewModels.Users.LoginRequestViewModel viewModel)
	{
		var result =
			await
			UserService.LoginAsync(viewModel: viewModel);

		return Ok(value: result);
	}

	[Microsoft.AspNetCore.Mvc.HttpGet(template: "{id?}")]
	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.ActionResult<Domain.Users.User>>
		PostAsync
		([Microsoft.AspNetCore.Mvc.FromRoute] int? id)
	{
		var result =
			await
			UserService.GetByIdAsync(id: id.Value);

		return Ok(value: result);
	}
}
