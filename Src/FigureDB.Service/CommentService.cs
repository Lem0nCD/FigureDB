using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateComment(Guid userId, Guid figureId, string content)
        {
            Comment comment = new Comment()
            {
                Content = content,
                UserId = userId,
                FigureId = figureId
            };
            await _repository.InsertAsync(comment);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<PaginationDTO<CommentDTO>> GetCommentsByFigureId(int index, int size, Guid id)
        {
            List<Comment> comments = await _repository
                .Find()
                .Include(c => c.User)
                .Where(c => c.FigureId == id)
                .OrderByDescending(c => c.CreateTime)
                .Skip(index * size)
                .Take(size)
                .ToListAsync();
            int count = await _repository.Find().Where(c => c.FigureId == id).CountAsync();
            List<CommentDTO> commentDTOs = _mapper.Map<List<CommentDTO>>(comments);
            return new PaginationDTO<CommentDTO>(count, commentDTOs);
        }

        public async Task<PaginationDTO<CommentDTO>> GetCommentsByUserId(int index, int size, Guid id)
        {
            List<Comment> comments = await _repository
                .Find()
                .Where(c => c.UserId == id)
                .OrderByDescending(c => c.CreateTime)
                .Skip(index * size)
                .Take(size)
                .ToListAsync();
            int count = await _repository.Find().Where(c => c.FigureId == id).CountAsync();
            List<CommentDTO> commentDTOs = _mapper.Map<List<CommentDTO>>(comments);
            return new PaginationDTO<CommentDTO>(count, commentDTOs);
        }
    }
}
