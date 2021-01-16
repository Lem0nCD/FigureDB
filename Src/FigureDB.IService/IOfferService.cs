using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IOfferService
    {
        public Task<List<Offer>> GetOfferByFigureId(Guid figureId);
        public Task<bool> CreateOffer(Guid figureId, Guid shopId, decimal price);
    }
}
