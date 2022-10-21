namespace Persistence;

public interface IUnitOfWork : IQueryUnitOfWork
{
	void Save();

	System.Threading.Tasks.Task SaveAsync
		(System.Threading.CancellationToken cancellationToken = default);
}
