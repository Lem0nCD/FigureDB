using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IFigureTagService
    {
        public Task<bool> CreateFigureTags(Guid figureId, List<int> tagIds);
        public Task<bool> CreateFigureTag(Guid figureId, int tagId);
    }
}
