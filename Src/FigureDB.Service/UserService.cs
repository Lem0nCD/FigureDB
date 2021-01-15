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
        //private readonly IUserIdentityService _identitySvc;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //public UserService(IGenericRepository<User, Guid> repository, /*IUserIdentityService identitySvc,*/ IMapper mapper, IUnitOfWork unitOfWork)
        //{
        //    this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        //    //_identitySvc = identitySvc ?? throw new ArgumentNullException(nameof(identitySvc));
        //    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        //    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        //}

        public UserService(IUserRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        //public UserService(IGenericRepository<User, Guid> repository,IUnitOfWork unitOfWork)
        //{
        //    this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        //    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        //}

        public async Task<bool> CreateUserAsync()
        {
            User user = new User()
            {
                Email = "545643@.com"
            };
            bool result = false;
            if (user != null)
            {
                await _repository.InsertAsync(user);
                result = await _unitOfWork.CommitAsync();
            }
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
