namespace Domain;

public interface IDomainEvent<TKey>
{
	TKey Id { get; }

	System.DateTime PublishDateTime { get; }
}
