﻿using AutoMapper;
using FigureDB.IService;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using FigureDB.WebAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FigureDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _service;
        private readonly IMapper _mapper;

        public ShopController(IShopService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<ShopController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ShopController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShopController>
        [Authorize]
        [HttpPost]
        public async Task<UnifyResponseDto> Post(ShopViewModel shopDTO)
        {
            var claims = User.Claims.ToList();
            Guid userId = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            Shop shop = new Shop()
            {
                Homepage = shopDTO.Homepage,
                Name = shopDTO.Name,
            };
            await _service.CreateShop(userId, shop);
            return UnifyResponseDto.Sucess();
        }

        // PUT api/<ShopController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShopController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
