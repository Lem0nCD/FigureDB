using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class SeriesRepository : GenericRepository<Series, int>, ISeriesRepository
    {
        public SeriesRepository(MainContext context) : base(context)
        {
        }
    }
}
