using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class FigureImageRepository : GenericRepository<FigureImage, Guid>, IFigureImageRepository
    {
        public FigureImageRepository(MainContext context) : base(context)
        {
        }
    }
}
