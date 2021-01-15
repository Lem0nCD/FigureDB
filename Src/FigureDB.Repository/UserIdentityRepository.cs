using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class UserIdentityRepository : GenericRepository<UserIdentity, Guid>, IUserIdentityRepository
    {
        public UserIdentityRepository(MainContext context) : base(context)
        {
        }
    }
}
