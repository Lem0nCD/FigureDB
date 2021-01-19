using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IFigureTypeService
    {
        public Task<List<FigureType>> GetFigureTypes();
    }
}
