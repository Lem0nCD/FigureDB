using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class FigureTypeRepository : GenericRepository<FigureType, int>, IFigureTypeRepository
    {
        public FigureTypeRepository(MainContext context) : base(context)
        {
        }
    }
}
