using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface ITagService
    {
        public Task<List<Tag>> GetAllTag();
        public Task<Tag> GetTag(int id);
        public Task<List<Tag>> GetFigureTagsByFigureId(Guid id);

    }
}
