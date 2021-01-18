using AutoMapper;
using FigureDB.IService;
using FigureDB.Model.DTO;
using FigureDB.WebAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FigureDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _service;
        private readonly IMapper _mapper;

        public FavoriteController(IFavoriteService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<FavoriteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FavoriteController>/5
        [HttpGet("{id}")]
        public async Task<PaginationDTO<FigureDTO>> Get(Guid id)
        {
            return await _service.GetFavoritesFigureByUserId(id);
        }

        // POST api/<FavoriteController>
        [HttpPost]
        [Authorize]
        public async Task<UnifyResponseDto> Post(FavoriteViewModel viewModel)
        {
            Guid userId = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            if (await _service.CreateFavorite(userId, viewModel.FigureId, viewModel.Type))
            {
                return UnifyResponseDto.Sucess();
            }
            return UnifyResponseDto.Fail();
        }

        // PUT api/<FavoriteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FavoriteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
