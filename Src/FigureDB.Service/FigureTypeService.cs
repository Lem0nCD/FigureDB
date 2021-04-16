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

        public async Task<List<List<FigureType>>> GetRecommandFigure()
        {
            var list1 = await _repository.Find().Where(x => x.Name == "手办").OrderByDescending(x => x.CreateTime).Take(8).ToListAsync();
            var list2 = await _repository.Find().Where(x => x.Name == "粘土人").OrderByDescending(x => x.CreateTime).Take(8).ToListAsync();
            var list3 = await _repository.Find().Where(x => x.Name == "高达").OrderByDescending(x => x.CreateTime).Take(8).ToListAsync();
            var list4 = await _repository.Find().Where(x => x.Name == "其他").OrderByDescending(x => x.CreateTime).Take(8).ToListAsync();
            var list5 = await _repository.Find().Where(_ => true).OrderByDescending(x => x.Id).Take(6).ToListAsync();
            List<List<FigureType>> bigList = new List<List<FigureType>>();
            bigList.Add(list1);
            bigList.Add(list2);
            bigList.Add(list3);
            bigList.Add(list4);
            bigList.Add(list5);
            return bigList;
        }
    }
}
