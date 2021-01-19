using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IUserIdentityService
    {
        public Task<bool> VerifyPasswordAsync(Guid userId, string credential);
        public Task<bool> VerifyPasswordAsync(string userName, string credential);
    }
    
}
