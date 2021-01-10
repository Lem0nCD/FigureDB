using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface ICharacterService
    {
        public Task<List<Character>> GetAllCharacter();
        public Task<Character> GetCharacter(int id);
    }
}
