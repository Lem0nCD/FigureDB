using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IFigureTypeService
    {
        public Task<List<FigureType>> GetAllFigureType();
        public Task<List<List<FigureType>>> GetRecommandFigure();
        public Task<bool> CreateFigureType(Guid figureId, string name);

    }
}
