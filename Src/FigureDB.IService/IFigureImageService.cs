using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IFigureImageService
    {
        public Task<FigureImage> CreateFigureImage(Guid figureId);
    }
}
