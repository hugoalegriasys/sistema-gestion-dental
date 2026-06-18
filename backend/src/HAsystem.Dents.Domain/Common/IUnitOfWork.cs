
namespace HAsystem.Dents.Domain.Common;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveAsync(CancellationToken cancellationToken = default(CancellationToken));
}
