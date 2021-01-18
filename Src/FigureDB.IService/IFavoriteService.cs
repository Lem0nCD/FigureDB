using FigureDB.Model.DTO;
using FigureDB.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IFavoriteService
    {
        public Task<bool> CreateFavorite(Guid userId, Guid figureId,FavoriteType type);
        public Task<List<int>> GetFavoritesByFigureId(Guid id);
        public Task<PaginationDTO<FigureDTO>> GetFavoritesFigureByUserId(Guid id, FavoriteType type);
        public Task<PaginationDTO<FigureDTO>> GetFavoritesFigureByUserId(Guid id);
    }
}
