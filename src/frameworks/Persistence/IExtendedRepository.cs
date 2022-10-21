namespace Persistence
{
	public interface IExtendedRepository<TDomain, TKey> :
		IRepository<TDomain, TKey> where TDomain : Domain.Entity<TKey>
	{
		// **************************************************
		void Delete
			(TDomain entity);

		bool DeleteById
			(TKey id);

		System.Threading.Tasks.Task
			DeleteAsync
			(TDomain entity,
			System.Threading.CancellationToken cancellation = default);

		System.Threading.Tasks.Task
			DeleteByIdAsync
			(TKey id,
			System.Threading.CancellationToken cancellation = default);
		// **************************************************

		// **************************************************
		void Update
			(TDomain entity);

		System.Threading.Tasks.Task
			UpdateAsync
			(TDomain entity,
			System.Threading.CancellationToken cancellation = default);
		// **************************************************

		// **************************************************
		void Insert
			(TDomain entity);

		System.Threading.Tasks.Task
			InsertAsync
			(TDomain entity,
			System.Threading.CancellationToken cancellation = default);
		// **************************************************

		// **************************************************
		void
			BulkInsert
			(System.Collections.Generic.IList<TDomain> entities);

		System.Threading.Tasks.Task
			BulkInsertAsync
			(System.Collections.Generic.IList<TDomain> entities,
			System.Threading.CancellationToken cancellation = default);
		// **************************************************
	}
}
