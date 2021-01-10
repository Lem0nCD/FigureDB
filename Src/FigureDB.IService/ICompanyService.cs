using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface ICompanyService
    {
        public Task<Company> GetCompany(int id);
        public Task<List<Company>> GetAllCompany();
    }
}
