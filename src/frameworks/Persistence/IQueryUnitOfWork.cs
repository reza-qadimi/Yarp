namespace Persistence;

public interface IQueryUnitOfWork : System.IDisposable
{
	bool IsDisposed { get; }
}
