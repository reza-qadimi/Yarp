namespace UserManagement.ViewModels.Base;

public class SearchResponseViewModel<T> : object
{
	public SearchResponseViewModel() : base()
	{
		Result =
			new System.Collections.Generic.List<T>();
	}

	public int PageSize { get; set; }

	public int TotalCount { get; set; }

	public int PageIndex { get; set; }

	public System.Collections.Generic.IList<T> Result { get; set; }
}
