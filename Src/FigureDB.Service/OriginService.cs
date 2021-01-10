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
    public class OriginService : IOriginService
    {
        private readonly IOriginRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OriginService(IOriginRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Origin>> GetAllOrigin()
        {
            return await _repository.Find().Where(_ => true).ToListAsync();
        }

        public async Task<Origin> GetOrigin(int id)
        {
            return await _repository.Find().Where(_ => true).FirstOrDefaultAsync();
        }
    }
}
