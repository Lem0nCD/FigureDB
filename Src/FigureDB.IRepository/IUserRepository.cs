using FigureDB.Model.Entities;
using System;

namespace FigureDB.IRepository
{
    public interface IUserRepository : IGenericRepository<User, Guid>
    {
    }
}
