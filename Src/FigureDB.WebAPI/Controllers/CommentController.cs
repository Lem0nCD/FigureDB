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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        private readonly IMapper _mapper;

        public CommentController(ICommentService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<CommentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public async Task<PaginationDTO<CommentDTO>> Get(Guid id, [FromQuery]ParametersViewModel viewModel,[FromQuery] string type)
        {
            switch (type)
            {
                case "figure":
                    return await _service.GetCommentsByFigureId(viewModel.Index, viewModel.Size, id);
                case "user":
                    return await _service.GetCommentsByUserId(viewModel.Index, viewModel.Size, id);
                default:
                    return await _service.GetCommentsByFigureId(viewModel.Index, viewModel.Size, id);

            }
        }

        // POST api/<CommentController>
        [HttpPost()]
        [Authorize]
        public async Task<UnifyResponseDto> Post(CommentViewModel viewModel)
        {
            Guid userId = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            if (await _service.CreateComment(userId, viewModel.FigureId, viewModel.Content))
            {
                return UnifyResponseDto.Sucess();
            }
            return UnifyResponseDto.Fail();
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
