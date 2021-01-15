using FigureDB.Model.Entities;
using System;
using System.Threading.Tasks;

namespace FigureDB.IRepository
{
    public interface IUserRepository : IGenericRepository<User, Guid>
    {
    }
}
