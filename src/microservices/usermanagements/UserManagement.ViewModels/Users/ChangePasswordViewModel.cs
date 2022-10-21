namespace UserManagement.ViewModels.Users;

public class ChangePasswordViewModel : object
{
	public ChangePasswordViewModel() : base()
	{
	}

	// **********
	public string? Username { get; set; }
	// **********

	// **********
	public string? Password { get; set; }
	// **********

	// **********
	public string? NewPassword { get; set; }
	// **********

	// **********
	public string? ConfirmPassword { get; set; }
	// **********
}
