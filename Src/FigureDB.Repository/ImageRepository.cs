using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class ImageRepository : GenericRepository<Image, Guid>, IImageRepository
    {
        public ImageRepository(MainContext context) : base(context)
        {
        }
    }
}
