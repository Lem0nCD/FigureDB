using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FigureDB.Service
{
    public class FigureService : IFigureService
    {
        public readonly IFigureRepository _rpository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FigureService(IFigureRepository rpository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _rpository = rpository ?? throw new ArgumentNullException(nameof(rpository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> AddFigure(Figure figure)
        {
            await _rpository.InsertAsync(figure);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<FigureDTO> GetFigure(Guid id)
        {
             var figure = await _rpository.Find()
                .Where(x => x.Id == id)
                .Include(x => x.Manufacturer)
                .Include(x => x.Published)
                .Include(x => x.Series)
                .Include(x => x.Origin)
                .Include(x => x.Character)
                .FirstAsync();
            return _mapper.Map<FigureDTO>(figure);
        }
    }
}
