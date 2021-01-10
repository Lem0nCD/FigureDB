using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using System;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IFigureService
    {
        public Task<FigureDTO> GetFigure(Guid id);
        public Task<bool> AddFigure(Figure figure);
    }
}
