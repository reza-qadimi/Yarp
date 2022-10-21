using Microsoft.VisualBasic;

namespace Framework.Modules;

[Microsoft.AspNetCore.Mvc.ApiController]
[Microsoft.AspNetCore.Mvc.Route
	(template: Constants.Routing.Controller)]
public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
	public ControllerBase() : base()
	{
	}
}
