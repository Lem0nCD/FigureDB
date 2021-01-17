using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
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

        public async Task<bool> CreateFigureImage(Guid figureId, Guid imageId, FigureImageType type)
        {
            FigureImage figureImage = new FigureImage()
            {
                FigureId = figureId,
                ImageId = imageId,
                FigureImageType = type
            };
            await _repository.InsertAsync(figureImage);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> CreateFigureImage(Guid figureId, Guid imageId)
        {
            FigureImage figureImage = new FigureImage()
            {
                FigureId = figureId,
                ImageId = imageId,
            };
            await _repository.InsertAsync(figureImage);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> CreateFigureImages(Guid figureId, IEnumerable<Guid> imageId)
        {
            foreach (var id in imageId)
            {
                await _repository.InsertAsync(new FigureImage()
                {
                    FigureId = figureId,
                    ImageId = id
                });
            }
            return await _unitOfWork.CommitAsync();

        }

        public async Task<List<FigureImage>> GetFigureImageByFigureId(Guid figureId)
        {
            return await _repository.Find()
                .Where(fi => fi.FigureId == figureId)
                .Include(fi => fi.Image)
                .ToListAsync();
        }
    }
}
