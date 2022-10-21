namespace HostService.Infrastructure.Settings;

public class Jwt : object
{

	public Jwt() : base()
	{
		SecretKey = string.Empty;
	}

	public string SecretKey { get; set; }

	public uint TokenExpiresInMinutes { get; set; }
}
