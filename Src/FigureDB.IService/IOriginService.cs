using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IOriginService
    {
        public Task<Origin> GetOrigin(int id);
        public Task<List<Origin>> GetAllOrigin();
    }
}
