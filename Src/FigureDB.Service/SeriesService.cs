using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Service
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesService _service;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SeriesService(ISeriesService service, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
