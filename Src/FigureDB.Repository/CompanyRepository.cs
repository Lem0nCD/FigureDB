using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class CompanyRepository : GenericRepository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(MainContext context) : base(context)
        {
        }
    }
}
