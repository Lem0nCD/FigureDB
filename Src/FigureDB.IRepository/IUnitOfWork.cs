using System.Threading.Tasks;

namespace FigureDB.IRepository
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        bool Commit();
    }
}
