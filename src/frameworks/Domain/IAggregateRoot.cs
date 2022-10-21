namespace Domain;

public interface IAggregateRoot<TKey> : IEntity<TKey>
{
	void ClearUncommittedEvents();

	System.Collections.Generic.IReadOnlyList
		<IDomainEvent<TKey>> GetUncommittedEvents();
}
