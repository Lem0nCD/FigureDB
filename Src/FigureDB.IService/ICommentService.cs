using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface ICommentService
    {
        public Task<PaginationDTO<CommentDTO>> GetCommentsByFigureId(int index, int size, Guid id);
        public Task<PaginationDTO<CommentDTO>> GetCommentsByUserId(int index, int size, Guid id);
        public Task<bool> CreateComment(Guid userId, Guid figureId, string content);
    }
}
