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
    public class OfferService  : IOfferService
    {
        private readonly IOfferRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfferService(IOfferRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateOffer(Guid figureId, Guid shopId, decimal price)
        {
            await _repository.InsertAsync(new Offer
            {
                FigureId = figureId,
                Price = price,
                ShopId = shopId
            });
            return await _unitOfWork.CommitAsync();
        }

        public async Task<List<Offer>> GetOfferByFigureId(Guid figureId)
        {
            return await _repository
                .Find()
                .Where(o => o.FigureId == figureId)
                .Include(o => o.Shop)
                .ToListAsync();
        }
    }
}
