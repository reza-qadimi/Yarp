namespace HostService.Infrastructure.Settings;

public class Policy : object
{
	public Policy() : base()
	{
		Name = string.Empty;

		ValidRoles =
			new
			System.Collections.Generic.List<string>();
	}

	public string Name { get; set; }

	public bool IsAuthenticated { get; set; }

	public System.Collections.Generic.IList<string> ValidRoles { get; set; }
}
