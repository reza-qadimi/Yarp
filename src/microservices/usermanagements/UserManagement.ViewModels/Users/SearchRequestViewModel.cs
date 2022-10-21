namespace UserManagement.ViewModels.Users;

public class SearchRequestViewModel : Base.SearchRequestViewModel
{
	public SearchRequestViewModel() : base()
	{
	}

	// **********
	public bool? IsActive { get; set; }
	// **********

	// **********
	public string? FirstName { get; set; }
	// **********

	// **********
	public string? LastName { get; set; }
	// **********

	// **********
	public string? Username { get; set; }
	// **********

	// **********
	public string? EmailAddress { get; set; }
	// **********

	// **********
	public Domain.Enums.UserType Type { get; set; }
	// **********

	// **********
	public string? CellPhoneNumber { get; set; }
	// **********

	// **********
	public System.DateTime InsertDateTime { get; set; }
	// **********
}
