using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface INewsService
    {
        public Task<bool> CreateNews(News news);
        public Task<PaginationDTO<NewsDTO>> GetNews(int index, int size);
        public Task<List<News>> GetNewsByFigureId();
    }
}
