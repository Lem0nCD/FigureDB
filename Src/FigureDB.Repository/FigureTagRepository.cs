using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class FigureTagRepository : GenericRepository<FigureTag, Guid>, IFigureTagRepository
    {
        public FigureTagRepository(MainContext context) : base(context)
        {
        }
    }
}
