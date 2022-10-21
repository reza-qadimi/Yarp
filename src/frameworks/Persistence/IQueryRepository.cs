namespace Persistence
{
	public interface IQueryRepository<TDomain, TKey> where TDomain : Domain.Entity<TKey>
	{
	}
}
