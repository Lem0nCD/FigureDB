using AutoMapper;
using FigureDB.IService;
using FigureDB.Model.Entities;
using FigureDB.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FigureDB.WebAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FigureDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<PaginationDTO<User>> Get()
        {
            List<User> users = await _service.GetUsersAsync();
            PaginationDTO<User> result = new PaginationDTO<User>(users.Count, users);
            return result;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(Guid id)
        {
            return await _service.GetUserAsync(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<UnifyResponseDto> Post(UserViewModel viewModel)
        {
            User user = _mapper.Map<User>(viewModel);
            if (await _service.CreateUserAsync(user, viewModel.Password))
            {
                return UnifyResponseDto.Sucess();
            }
            return UnifyResponseDto.Fail();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
