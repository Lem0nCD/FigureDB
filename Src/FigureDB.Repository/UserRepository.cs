using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;

namespace FigureDB.Repository
{
    public class UserRepository : GenericRepository<User, Guid>,IUserRepository
    {
        public UserRepository(MainContext context) : base(context)
        {
        }
    }
}
