using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IUserService
    {
        public Task<User> GetUserAsync(Guid id);
        public Task<User> GetUserAsync(string nickName);
        public Task<List<User>> GetUsersAsync();
        public Task<bool> CreateUserAsync();
    }
}
