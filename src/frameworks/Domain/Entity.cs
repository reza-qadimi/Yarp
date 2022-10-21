namespace Domain
{
	public class Entity<TKey> : object, IEntity<TKey>
	{
		public Entity() : base()
		{
		}

		public TKey Id { get; set; }
	}
}
