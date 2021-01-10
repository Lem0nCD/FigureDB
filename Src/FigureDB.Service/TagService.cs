using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
using FigureDB.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.Service
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IFigureTagRepository _ftRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository, IFigureTagRepository ftRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _ftRepository = ftRepository ?? throw new ArgumentNullException(nameof(ftRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Tag>> GetAllTag()
        {
            return await _repository.Find().Where(_ => true).ToListAsync();
        }

        public async Task<List<Tag>> GetFigureTagsByFigureId(Guid id)
        {
            return await _ftRepository.Find()
                .Where(ft => ft.FigureId == id)
                .Include(ft => ft.Tag)
                .Select(ft => ft.Tag)
                .OrderBy(t => t.Id)
                .ToListAsync();
        }

        public async Task<Tag> GetTag(int id)
        {
            return await _repository.FindAsync(id);
        }


    }
}
