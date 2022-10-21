namespace Persistence;

public interface IExtendedQueryRepository<TDomain, TKey> :
	IQueryRepository<TDomain, TKey> where TDomain : Domain.Entity<TKey>
{
	// **************************************************
	TDomain GetById(TKey id);

	System.Threading.Tasks.Task
		<TDomain> GetByIdAsync
		(TKey id, System.Threading.CancellationToken cancellationToken = default);
	// **************************************************

	// **************************************************
	System.Collections.Generic.IList<TDomain> GetAll();

	System.Threading.Tasks.Task
		<System.Collections.Generic.IList<TDomain>> GetByAllAsync
		(System.Threading.CancellationToken cancellationToken = default);
	// **************************************************
}
