using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
using FigureDB.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.Service
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly IUserIdentityRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserIdentityService(IUserIdentityRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<bool> VerifyPasswordAsync(Guid userId, string credential)
        {
            return await _repository.Find()
                .Where(ui => ui.UserId == userId && ui.Credential == credential)
                .CountAsync() == 1;
        }

        public async Task<bool> VerifyPasswordAsync(string userName, string credential)
        {
            var userIdentitys = (await _userRepository
                .Find()
                .Where(u => u.Nickname == userName)
                .Select(u => u.UserIdentitys)
                .FirstOrDefaultAsync()).ToList();

            foreach (var ui in userIdentitys)
            {
                if (ui.IdentityType == Model.Entity.IdentityType.Password && ui.Credential == credential)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
