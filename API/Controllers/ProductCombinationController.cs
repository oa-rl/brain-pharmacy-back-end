using System;
using API.Dtos;
using API.Helpers;
using API.Logic;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductCombinationController : BaseController
    {
        private readonly IGenericRepository<ProductCombinationEntity> _productCombination;
        private readonly IMapper _mapper;
        private readonly ProductCombinationLogic _productCombinationLogic;

        public ProductCombinationController(IGenericRepository<ProductCombinationEntity> product, IMapper mapper)
        {
            _productCombination = product;
            _mapper = mapper;
            _productCombinationLogic = new(_productCombination, _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductCombinationDto>>> GetProducts([FromQuery] ProductCombinationSpecParams productParams)
        {
            Pagination<ProductCombinationDto> product = await _productCombinationLogic.GetProductLogic(productParams);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCombinationDto>> GetProduct(int id)
        {
            ProductCombinationDto product = await _productCombinationLogic.GetProductIdLogic(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ResponseOk<ProductCombinationDto>> PostProduct([FromBody] ProductCombinationEntity product)
        {
            return await _productCombinationLogic.PostProduct(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductCombinationDto>> PutBranch([FromBody] ProductCombinationEntity branch)
        {
            ProductCombinationDto update = await _productCombinationLogic.PutProduct(branch);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<ProductCombinationDto>> DeleteBranch([FromBody] ProductCombinationEntity branch)
        {
            ProductCombinationDto delete = await _productCombinationLogic.DeleteProduct(branch);
            return Ok(delete);
        }


    }
}

