using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class OriginRepository : GenericRepository<Origin, int>, IOriginRepository
    {
        public OriginRepository(MainContext context) : base(context)
        {
        }
    }
}
