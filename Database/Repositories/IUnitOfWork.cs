using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartSence.Database.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit(CancellationToken cancellationToken);

        Task Commit();

        void Rollback();
    }
}