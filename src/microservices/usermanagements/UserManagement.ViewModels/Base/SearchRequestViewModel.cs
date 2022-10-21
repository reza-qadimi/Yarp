namespace UserManagement.ViewModels.Base;

public class SearchRequestViewModel : object
{
	public SearchRequestViewModel() : base()
	{
		PageSize = 1;
	}

	public int PageSize { get; set; }

	public int TotalCount { get; set; }

	public int PageIndex { get; set; }
}
