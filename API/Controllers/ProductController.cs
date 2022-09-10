using API.Dtos;
using API.Helpers;
using API.Logic;
using AutoMapper;
using core;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IGenericRepository<ProductEntity> _product;
        private readonly IMapper _mapper;
        private readonly ProductLogic _productLogic;

        public ProductController(IGenericRepository<ProductEntity> product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
            _productLogic = new(_product, _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            Pagination<ProductDto> product = await _productLogic.GetProductLogic(productParams);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            ProductDto product = await _productLogic.GetProductIdLogic(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ResponseOk<ProductDto>> PostProduct([FromBody] ProductEntity product)
        {
            return await _productLogic.PostProduct(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> PutBranch([FromBody] ProductEntity branch)
        {
            ProductDto update = await _productLogic.PutProduct(branch);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<ProductDto>> DeleteBranch([FromBody] ProductEntity branch)
        {
            ProductDto delete = await _productLogic.DeleteProduct(branch);
            return Ok(delete);
        }
    }
}
