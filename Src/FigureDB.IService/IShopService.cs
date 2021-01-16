using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IShopService
    {
        public Task<bool> CreateShop(Guid userId, Shop shop);
        public Task<Shop> GetShopByUserId(Guid userId);
    }
}
