namespace Jwt.Infrastructure.Exceptions;

public class SecretKeyMustNotBeNullOrWhiteSpaceException : System.Exception
{
	public SecretKeyMustNotBeNullOrWhiteSpaceException() : base()
	{
	}
}

public class InvalidAuthenticationException : System.Exception
{
	public InvalidAuthenticationException() : base()
	{
	}
}
