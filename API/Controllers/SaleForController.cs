using System;
using API.Dtos;
using API.Helpers;
using API.Logic;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class SaleForController: BaseController
    {
        private readonly IGenericRepository<SaleForEntity> _saleFor;
        private readonly IMapper _mapper;
        private readonly SaleForLogic _saleForLogic;

        public SaleForController(IGenericRepository<SaleForEntity> saleFor, IMapper mapper)
        {
            _saleFor = saleFor;
            _mapper = mapper;
            _saleForLogic = new(_saleFor, _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SaleForDto>>> GetSaleFor([FromQuery] SaleForSpecParams saleForParams)
        {
            Pagination<SaleForDto> saleFor = await _saleForLogic.GetSaleForLogic(saleForParams);
            return Ok(saleFor);
        }
    }
}

