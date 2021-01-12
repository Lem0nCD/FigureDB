using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IFigureService
    {
        public Task<FigureDTO> GetFigure(Guid id);
        public Task<PaginationDTO<List<FigureDTO>>> GetFigures(int index,int size);
        public Task<bool> CreateFigure(Figure figure);
    }
}
