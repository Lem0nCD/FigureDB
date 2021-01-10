using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Repository
{
    public class CharacterRepository : GenericRepository<Character, int>, ICharacterRepository
    {
        public CharacterRepository(MainContext context) : base(context)
        {
        }
    }
}
