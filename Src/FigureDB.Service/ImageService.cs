using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
using FigureDB.Model.Entities;
using FigureDB.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.Service
{
    public class ImageService : IImageService
    {
        private readonly ImageRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ImageService(ImageRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateImage(string basePath)
        {
            Image image = new Image()
            {
                Path = basePath
            };
            await _repository.InsertAsync(image);
            return await _unitOfWork.CommitAsync();
        }
    }
}
