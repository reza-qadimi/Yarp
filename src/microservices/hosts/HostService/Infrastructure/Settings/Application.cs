namespace HostService.Infrastructure.Settings;

public class Application : object
{
	public readonly static string KeyName = "ApplicationSetting";

	public Application() : base()
	{
		Jwt = new();

		Policies =
			new
			System.Collections.Generic.List<Policy>();
	}

	public Jwt Jwt { get; set; }

	public System.Collections.Generic.IList<Policy> Policies { get; set; }
}
