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
    public class ShopService : IShopService
    {
        private readonly IShopRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShopService(IShopRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateShop(Guid userId, Shop shop)
        {
            shop.UserId = userId;
            await _repository.InsertAsync(shop);
            return await _unitOfWork.CommitAsync();
        }

        public Task<Shop> GetShopByUserId(Guid userId)
        {
            return _repository
                .Find()
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync();
        }
    }
}
