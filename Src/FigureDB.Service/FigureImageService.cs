using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.Service
{
    public class FigureImageService : IFigureImageService
    {
        private readonly IFigureImageRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FigureImageService(IFigureImageRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<FigureImage> CreateFigureImage(Guid figureId)
        {
            var figureImage = new FigureImage()
            {
                FigureId = figureId
            };
            await _repository.InsertAsync(figureImage);
            try
            {
                await _unitOfWork.CommitAsync();
                return figureImage;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
