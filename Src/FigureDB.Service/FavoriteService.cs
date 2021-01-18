using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using FigureDB.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.Service
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepostiroy _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FavoriteService(IFavoriteRepostiroy repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateFavorite(Guid userId, Guid figureId, FavoriteType type = FavoriteType.Follow)
        {
            if (await _repository.Find().Where(f => f.UserId == userId && f.FigureId == figureId).CountAsync() > 0)
            {
                return false;
            }
            Favorite favorite = new Favorite
            {
                FigureId = figureId,
                UserId = userId,
                Type = type,
            };
            await _repository.InsertAsync(favorite);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<List<int>> GetFavoritesByFigureId(Guid id)
        {
            List<int> favoritesTypeCount = new List<int>();
            favoritesTypeCount.Add(await _repository.Find().Where(f => f.Id == id && f.Type == FavoriteType.Follow).CountAsync());
            favoritesTypeCount.Add(await _repository.Find().Where(f => f.Id == id && f.Type == FavoriteType.WantTo).CountAsync());
            favoritesTypeCount.Add(await _repository.Find().Where(f => f.Id == id && f.Type == FavoriteType.Preorder).CountAsync());
            favoritesTypeCount.Add(await _repository.Find().Where(f => f.Id == id && f.Type == FavoriteType.Bought).CountAsync());
            return favoritesTypeCount;
        }

        public async Task<PaginationDTO<FigureDTO>> GetFavoritesFigureByUserId(Guid id, FavoriteType type)
        {
            var query = _repository
                .Find()
                .Where(f => f.UserId == id && f.Type == type);
            int total = await query.CountAsync();
            var figures = await query.OrderByDescending(f => f.CreateTime).Select(f => f.Figure).ToListAsync();
            return new PaginationDTO<FigureDTO>(total, _mapper.Map<List<FigureDTO>>(figures));
        }

        public async Task<PaginationDTO<FigureDTO>> GetFavoritesFigureByUserId(Guid id)
        {
            var query = _repository
                .Find()
                .Where(f => f.UserId == id)
                .Include(f => f.Figure)
                .ThenInclude(f => f.Character)
                .Include(f => f.Figure)
                .ThenInclude(f => f.Manufacturer)
                .Include(f => f.Figure)
                .ThenInclude(fi => fi.FigureImages)
                .ThenInclude(fi => fi.Image)
                .Select(f => f.Figure);
            int total = await query.CountAsync();
            var figures = await query
                .OrderByDescending(f => f.CreateTime)
                .ToListAsync();
            return new PaginationDTO<FigureDTO>(total, _mapper.Map<List<FigureDTO>>(figures));
        }
    }
}
