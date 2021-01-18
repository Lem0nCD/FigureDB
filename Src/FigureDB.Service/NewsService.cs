using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.Service
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewsService(INewsRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateNews(News news)
        {
            await _repository.InsertAsync(news);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<PaginationDTO<NewsDTO>> GetNews(int index, int size)
        {
            var news = await _repository.Find()
                .Where(_ => true)
                .Skip(index * size)
                .Take(size)
                .OrderByDescending(n => n.CreateTime)
                .Include(n => n.Figure)
                .ThenInclude(f => f.FigureImages)
                .ThenInclude(fi => fi.Image)
                .ToListAsync();
            int total = await _repository.Find()
                .Where(_ => true)
                .CountAsync();
            var newsDTOs = _mapper.Map<List<NewsDTO>>(news);
            return new PaginationDTO<NewsDTO>()
            {
                Data = newsDTOs,
                Total = total
            };
        }

        public async Task<List<News>> GetNewsByFigureId(Guid figureId)
        {
            return await _repository.Find()
                .Where(n => n.FigureId == figureId)
                .OrderBy(n => n.CreateTime)
                .Include(n => n.Figure)
                .ToListAsync();
        }
    }
}
