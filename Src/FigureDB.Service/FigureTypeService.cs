using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
