using System.Threading.Tasks;

namespace Inspirator.IRepository
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        bool Commit();
    }
}
