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
    public class FigureTypeService : IFigureTypeService
    {
        private readonly IFigureTypeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FigureTypeService(IFigureTypeRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateFigureType(Guid figureId, string name)
        {
            FigureType figureType = new FigureType()
            {
                FigureId = figureId,
                Name = name,
            };
            await _repository.InsertAsync(figureType);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<List<FigureType>> GetAllFigureType()
        {
            return await _repository.Find().Where(_ => true).ToListAsync();
        }
    }
}
