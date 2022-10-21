namespace Jwt.Infrastructure.Settings;

public class Main : object
{
	public readonly static string KeyName = "JwtSetting";

	public Main() : base()
	{
		SecretKey = string.Empty;
	}

	public string SecretKey { get; set; }

	public uint TokenExpiresInMinutes { get; set; }
}
