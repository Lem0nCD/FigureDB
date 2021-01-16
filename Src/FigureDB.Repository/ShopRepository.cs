using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class ShopRepository : GenericRepository<Shop, Guid>, IShopRepository
    {
        public ShopRepository(MainContext context) : base(context)
        {
        }
    }
}
