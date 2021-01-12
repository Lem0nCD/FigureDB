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
    public class FigureTagService : IFigureTagService
    {
        private readonly IFigureTagRepository _resitory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FigureTagService(IFigureTagRepository resitory, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _resitory = resitory ?? throw new ArgumentNullException(nameof(resitory));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateFigureTag(Guid figureId, int tagId)
        {
            await _resitory.InsertAsync(new FigureTag()
            {
                FigureId = figureId,
                TagId = tagId
            });
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> CreateFigureTags(Guid figureId, List<int> tagIds)
        {
            foreach (int tagId in tagIds)
            {
                await _resitory.InsertAsync(new FigureTag()
                {
                    FigureId = figureId,
                    TagId = tagId
                });
            }
            return await _unitOfWork.CommitAsync();
        }
    }
}
