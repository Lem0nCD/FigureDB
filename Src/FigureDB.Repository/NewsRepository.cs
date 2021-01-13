using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class NewsRepository : GenericRepository<News, Guid>, INewsRepository
    {
        public NewsRepository(MainContext context) : base(context)
        {
        }
    }
}
