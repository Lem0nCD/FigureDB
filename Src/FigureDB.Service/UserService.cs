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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUserIdentityRepository _userIdentityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public UserService(IUserRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<bool> CreateUserAsync(User user, string password)
        {
            bool result = false;
            if (user != null)
            {
                await _repository.InsertAsync(user);
            }
            UserIdentity identity = new UserIdentity(Model.Entity.IdentityType.Password, password, user.Id);
            await _userIdentityRepository.InsertAsync(identity);
            result = await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _repository.FindAsync(id);
        }


        public async Task<List<User>> GetUsersAsync()
        {
            return await _repository.Find().ToListAsync();
        }

        public Task<User> GetUserAsync(string nickName)
        {
            return _repository.Find().Where(u => u.Nickname == nickName)
                .FirstOrDefaultAsync();
        }
    }
}
