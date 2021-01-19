using AutoMapper;
using FigureDB.IService;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
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
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _service;
        private readonly IShopService _shopService;
        private readonly IMapper _mapper;

        public OfferController(IOfferService service, IShopService shopService, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _shopService = shopService ?? throw new ArgumentNullException(nameof(shopService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<OfferController>
        [HttpGet("{id}")]
        public async Task<List<OfferDTO>> Get(Guid id)
        {
            var offers = await _service.GetOfferByFigureId(id);
            return _mapper.Map<List<OfferDTO>>(offers);
        }

        // POST api/<OfferController>
        [Authorize]
        [HttpPost]
        public async Task<UnifyResponseDto> Post(OfferViewModel viewModel)
        {
            Guid userId = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            var shop = await _shopService.GetShopByUserId(userId);
            if (await _service.CreateOffer(viewModel.FigureId, shop.Id, viewModel.Price))
            {
                return UnifyResponseDto.Sucess();
            }
            return UnifyResponseDto.Fail();
        }

        // PUT api/<OfferController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OfferController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
