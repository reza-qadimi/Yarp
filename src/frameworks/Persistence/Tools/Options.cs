namespace Persistence.Tools
{
	public class Options : object
	{
		public Options() : base()
		{
		}

		public string? ConnectionString { get; set; }

		public Enumerations.Provider Provider { get; set; }
	}
}
