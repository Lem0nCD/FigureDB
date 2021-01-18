using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class CommentRepository : GenericRepository<Comment, Guid>, ICommentRepository
    {
        public CommentRepository(MainContext context) : base(context)
        {
        }
    }
}
