using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class OffersRepository : GenericRepository<Offer, Guid>, IOfferRepository
    {
        public OffersRepository(MainContext context) : base(context)
        {
        }
    }
}
