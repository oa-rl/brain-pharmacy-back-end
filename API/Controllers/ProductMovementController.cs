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
    public class ProductMovementController: BaseController
    {
        private readonly IGenericRepository<ProductMovementEntity> _productMovement;
        private readonly IMapper _mapper;
        private readonly ProductMovementLogic _productMovementLogic;

        public ProductMovementController(IGenericRepository<ProductMovementEntity> user, IMapper mapper)
        {
            _productMovement = user;
            _mapper = mapper;
            _productMovementLogic = new(_productMovement, _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductMovementDto>>> GetProductMovements([FromQuery] ProductMovementSpecParams productMovementParams)
        {
            Pagination<ProductMovementDto> product = await _productMovementLogic.GetProductMovementLogic(productMovementParams);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductMovementDto>> GetProductMovement(int id)
        {
            ProductMovementDto product = await _productMovementLogic.GetProductMovementIdLogic(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ResponseOk<ProductMovementDto>> PostProductMovement([FromBody] ProductMovementEntity user)
        {
            return await _productMovementLogic.PostProductMovement(user);
        }

        [HttpPut]
        public async Task<ActionResult<ProductMovementDto>> PutProductMovement([FromBody] ProductMovementEntity user)
        {
            ProductMovementDto update = await _productMovementLogic.PutProductMovement(user);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<ProductMovementDto>> DeleteProductMovement([FromBody] ProductMovementEntity user)
        {
            ProductMovementDto delete = await _productMovementLogic.DeleteProductMovement(user);
            return Ok(delete);
        }
    }
}
