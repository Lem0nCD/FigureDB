using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface ISeriesService
    {
        public Task<Series> GetSeries();
        public Task<List<Series>> GetAllSeries();
    }
}
