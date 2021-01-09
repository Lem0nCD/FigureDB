using FigureDB.Model.Entities;
using System;

namespace FigureDB.IRepository
{
    public interface IFigureRepository : IGenericRepository<Figure, Guid>
    {
    }
}
