using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class FavoriteRepostiroy : GenericRepository<Favorite, Guid>, IFavoriteRepostiroy
    {
        public FavoriteRepostiroy(MainContext context) : base(context)
        {
        }
    }
}
