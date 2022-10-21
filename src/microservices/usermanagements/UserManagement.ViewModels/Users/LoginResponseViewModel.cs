namespace UserManagement.ViewModels.Users;

public class LoginResponseViewModel : object
{
	public LoginResponseViewModel
		(int id, string username, string role, string token) : base()
	{
		Id = id;

		Token = token;

		UserType = role;

		Username = username;
	}

	public int Id { get; set; }

	public string Token { get; set; }

	public string Username { get; set; }

	public string UserType { get; set; }
}
