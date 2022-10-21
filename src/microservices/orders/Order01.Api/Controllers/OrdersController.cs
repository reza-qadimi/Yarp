namespace Order01.Api.Controllers;

public class OrdersController : Framework.Modules.ControllerBase
{
	[Microsoft.AspNetCore.Mvc.HttpGet(template: "{value}")]
	public Microsoft.AspNetCore.Mvc.IActionResult Index(string value)
	{
		return Ok
			($"Order Service: 01 - {nameof(value)}: {value}");
	}

	[Microsoft.AspNetCore.Mvc.HttpGet(template: "health-check")]
	public async
		System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> Health()
	{
		//throw new System.Exception();
		//return StatusCode(statusCode: 500);
		//await System.Threading.Tasks.Task.Delay(20000);

		await System.Threading.Tasks.Task.CompletedTask;

		return Ok();
	}
}
