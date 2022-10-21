namespace Persistence
{
	public interface IExtraExtendedRepository<TDomain, TKey> :
		IExtendedRepository<TDomain, TKey>, IExtendedQueryRepository<TDomain, TKey>
		where TDomain : Domain.Entity<TKey>
	{
	}
}
