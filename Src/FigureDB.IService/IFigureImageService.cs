using FigureDB.Model.Entities;
using FigureDB.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IFigureImageService
    {
        public Task<bool> CreateFigureImage(Guid figureId, Guid imageId, FigureImageType type);
        public Task<bool> CreateFigureImage(Guid figureId, Guid imageId);
        public Task<bool> CreateFigureImages(Guid figureId, IEnumerable<Guid> imageId);
        public Task<List<FigureImage>> GetFigureImageByFigureId(Guid figureId);
        public Task<FigureImage> GetFigureCoverImageByFigureId(Guid figureId);
    }
}
