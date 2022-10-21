namespace Persistence
{
	public interface IRepository<TDomain, TKey> :
		IQueryRepository<TDomain, TKey> where TDomain : Domain.Entity<TKey>
	{
	}
}
