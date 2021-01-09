using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;

namespace FigureDB.Repository
{
    public class TagRepository : GenericRepository<Tag,int> , ITagRepository
    {
        public TagRepository(MainContext context) : base(context)
        {

        }
    }
}
