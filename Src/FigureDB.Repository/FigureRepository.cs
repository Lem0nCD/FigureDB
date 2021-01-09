using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class FigureRepository : GenericRepository<Figure, Guid>, IFigureRepository
    {
        public FigureRepository(MainContext context) : base(context)
        {
        }
    }
}
