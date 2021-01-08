using FigureDB.IRepository;
using FigureDB.Model.Context;
using System;
using System.Threading.Tasks;

namespace FigureDB.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _mainContext;

        public UnitOfWork(MainContext mainContext)
        {
            _mainContext = mainContext ?? throw new ArgumentNullException(nameof(mainContext));
        }

        public bool Commit()
        {
            return _mainContext.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return await _mainContext.SaveChangesAsync() > 0;
        }
    }
}
