namespace UserManagement.Domain.Base;

public class Entity : object
{
	public Entity() : base()
	{
		//Id =
		//	System.Guid.NewGuid();
	}

	// **********
	public int Id { get; set; }
	//public System.Guid Id { get; set; }
	// **********
}
